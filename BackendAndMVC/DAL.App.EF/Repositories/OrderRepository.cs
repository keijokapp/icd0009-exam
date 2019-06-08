using System.Collections.Generic;
using System.Linq;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain;
using ee.itcollege.akaver.Contracts.DAL.Base.Mappers;
using ee.itcollege.akaver.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class OrderRepository : BaseRepository<Order, Order, AppDbContext>, IOrderRepository
    {
        public OrderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new IdentityFunctionMapper())
        {
            
        }

        public IEnumerable<Order> AllByUser(int userId)
        {
            return RepositoryDbSet.Where(o => o.UserId == userId).AsEnumerable();
        }
    }
}