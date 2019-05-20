using ee.itcollege.akaver.Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppRole : IdentityRole<int>, IDomainEntity // PK type is int
    {
        
    }
}