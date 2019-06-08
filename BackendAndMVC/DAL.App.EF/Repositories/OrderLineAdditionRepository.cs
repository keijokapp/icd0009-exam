using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain;
using ee.itcollege.akaver.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class OrderLineAdditionRepository : BaseRepository<OrderLineAddition, OrderLineAddition, AppDbContext>, IOrderLineAdditionRepository
    {
        public OrderLineAdditionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext,
            new IdentityFunctionMapper())
        {
        }
    }
}