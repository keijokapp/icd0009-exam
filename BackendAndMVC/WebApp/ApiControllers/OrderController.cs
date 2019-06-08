using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using ee.itcollege.akaver.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Mappers;
using Order = WebApp.DTO.Order;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly OrderMapper _mapper = new OrderMapper();
        
        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var userId = HttpContext.User.GetUserId();

            var user = _context.Users.Find(userId);

            var q = await _userManager.IsInRoleAsync(user, "Admin") ? _context.Orders : _context.Orders.Where(o => o.UserId == userId);
            
            return Ok(q.Include(o => o.User)
                .Include(o => o.OrderLines)
                    .ThenInclude(l => l.OrderLineAdditions)
                    .ThenInclude(o => o.Product)
                .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Product)
                .Select(o => _mapper.MapFromDal(o)).AsEnumerable());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            if (order.UserId != HttpContext.User.GetUserId())
            {
                var user = _context.Users.Find(id);
                if(!await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return NotFound();
                }
            }

            return _mapper.MapFromDal(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            var o = new Domain.Order
            {
                DeliveryLocation = order.DeliveryLocation,
                UserId =  HttpContext.User.GetUserId(),
                State = OrderState.Waiting,
                OrderLines = new List<OrderLine>(),
                Price = 0
            };

            foreach (var line in order.OrderLines)
            {
                var product = _context.Products.Find(line.ProductId);

                var oLine = new OrderLine
                {
                    Price = product.Price,
                    Quantity = line.Quantity,
                    Product = product
                };
                
                o.OrderLines.Add(oLine);

                o.Price += line.Quantity * product.Price;

                oLine.OrderLineAdditions = new List<OrderLineAddition>();

                foreach (var addition in line.OrderLineAdditions)
                {
                    product = _context.Products.Find(addition.ProductId);
                    oLine.OrderLineAdditions.Add(new Domain.OrderLineAddition
                    {
                        Price = product.Price,
                        Quantity = addition.Quantity,
                        Product = product
                    });
                }
            }
            
            _context.Orders.Add(o);
            await _context.SaveChangesAsync();

            return Ok(new { id = order.Id });
        }

        [HttpPut("{id}/state")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> SetState(int id, OrderState state)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            order.State = state;

            _context.Orders.Update(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
