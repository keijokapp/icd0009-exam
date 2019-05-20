using System;
using System.Collections.Generic;
using Domain.Identity;

namespace Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public int PublishingYear { get; set; }


        public ICollection<BookAndAuthor> BookAndAuthors { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Comment> Comments { get; set; }


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}