using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product : BaseEntity
    {
        [Required]
        public Category Category { get; set; }

        [Required]
        public string Name { get; set; }

        public int Price { get; set; }
    }
}