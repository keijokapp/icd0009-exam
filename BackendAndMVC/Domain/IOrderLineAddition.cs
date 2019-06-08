using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class OrderLineAddition : BaseEntity
    {
        [Required] 
        public OrderLine OrderLine { get; set; }

        [Required]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}