using Domain;

namespace WebApp.Models
{
    public class BookCreateVM
    {
        public Book Book { get; set; }
        public int AuthorId { get; set; }
    }
}