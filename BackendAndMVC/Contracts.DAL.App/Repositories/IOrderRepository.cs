using System.Collections.Generic;
using Domain;
using ee.itcollege.akaver.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IEnumerable<Order> AllByUser(int userId);
    }
}