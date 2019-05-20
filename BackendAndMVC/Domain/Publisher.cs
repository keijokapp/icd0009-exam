using System.Collections.Generic;

namespace Domain
{
    public class Publisher : BaseEntity
    {
        public string PublisherName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}