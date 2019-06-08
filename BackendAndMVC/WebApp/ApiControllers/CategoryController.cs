using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class CategoryController : ControllerBase
	{
		private readonly AppDbContext _context;

		public CategoryController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<Category>>> Get()
		{
			return Ok(await _context.Category.ToListAsync());
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Category>> Get(int id)
		{
			var category = await _context.Category.FindAsync(id);
			if (category == null)
			{
				return NotFound();
			}

			return category;
		}

		[HttpPost]
		public async Task<ActionResult<Category>> Post(Category category)
		{
			_context.Category.Add(category);
			await _context.SaveChangesAsync();

			return Ok(new { id = category.Id });
		}
	}
}