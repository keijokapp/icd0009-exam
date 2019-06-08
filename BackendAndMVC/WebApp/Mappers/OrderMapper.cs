using System.Linq;
using Domain;

namespace WebApp.Mappers
{
	public class OrderMapper
	{
		public DTO.Order MapFromDal(Order order)
		{
			return new DTO.Order
			{
				Id = order.Id,
				Price = order.Price,
				State = order.State,
				DeliveryLocation = order.DeliveryLocation,
				User = new DTO.Order.OrderUser
				{
					UserId = order.User.Id,
					UserName = order.User.UserName
				},
				OrderLines = order.OrderLines.Select(_mapOrderLineFromDal)
			};
		}

		private DTO.Order.OrderLine _mapOrderLineFromDal(OrderLine orderLine)
		{
			return new DTO.Order.OrderLine
			{
				Price = orderLine.Price,
				Quantity = orderLine.Quantity,
				ProductId = orderLine.Product.Id,
				ProductName = orderLine.Product.Name,
				OrderLineAdditions = orderLine.OrderLineAdditions.Select(_mapOrderLineAdditionFromDal).ToList()
			};
		}

		private DTO.Order.OrderLineAddition _mapOrderLineAdditionFromDal(OrderLineAddition addition)
		{
			return new DTO.Order.OrderLineAddition
			{
				Price = addition.Price,
				Quantity = addition.Quantity,
				ProductId = addition.Product.Id,
				ProductName = addition.Product.Name
			};
		}
	}
}