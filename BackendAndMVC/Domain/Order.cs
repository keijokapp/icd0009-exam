using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        [Required]
        public AppUser User { get; set; }

        public OrderState State { get; set; }

        [Required]
        public string DeliveryLocation { get; set; }

        public int Price { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}