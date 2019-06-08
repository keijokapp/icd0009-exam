using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.DTO
{
	public class Order
	{
		public int Id { get; set; }

		public OrderUser User { get; set; }

		public Domain.OrderState State { get; set; }

		public string DeliveryLocation { get; set; }
		
		public int Price { get; set; }

		[Required]
		public IEnumerable<OrderLine> OrderLines { get; set; }

		public class OrderLine
		{
			[Required]
			public int ProductId { get; set; }

			public string ProductName { get; set; }

			public int Quantity { get; set; }

			public int Price { get; set; }

			[Required]
			public List<OrderLineAddition> OrderLineAdditions { get; set; }
		}

		public class OrderLineAddition
		{
			[Required]
			public int ProductId { get; set; }

			[Required]
			public string ProductName { get; set; }

			public int Quantity { get; set; }

			public int Price { get; set; }
		}
		
		public class OrderUser
		{
			public int UserId { get; set; }
			
			[Required]
			public string UserName { get; set; }
		}
	}
}