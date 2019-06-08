using System.ComponentModel.DataAnnotations;

namespace WebApp.DTO
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Domain.CategoryType CategoryType { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}