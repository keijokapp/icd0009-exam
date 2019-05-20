using System.Collections.Generic;
using ee.itcollege.akaver.Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser :  IdentityUser<int>, IDomainEntity // PK type is int
    {
        public ICollection<Book> Books { get; set; }
    }
}