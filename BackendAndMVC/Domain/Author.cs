using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int YearOfBirth { get; set; }


        public ICollection<BookAndAuthor> BookAndAuthors { get; set; }
        
        public string FirstLastName => FirstName + " " + LastName;
    }
}