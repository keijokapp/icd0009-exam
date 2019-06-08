using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class OrderLine : BaseEntity
    {
        [Required] 
        public Order Order { get; set; }

        [Required]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public List<OrderLineAddition> OrderLineAdditions { get; set; }
    }
}