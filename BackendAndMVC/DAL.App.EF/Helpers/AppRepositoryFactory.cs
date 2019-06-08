using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using ee.itcollege.akaver.DAL.Base.EF.Helpers;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory<AppDbContext>
    {
        public AppRepositoryFactory()
        {
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            AddToCreationMethods<IOrderRepository>(dataContext => new OrderRepository(dataContext));
            AddToCreationMethods<IProductRepository>(dataContext => new ProductRepository(dataContext));
            AddToCreationMethods<IOrderLineRepository>(dataContext => new OrderLineRepository(dataContext));
            AddToCreationMethods<IOrderLineAdditionRepository>(dataContext => new OrderLineAdditionRepository(dataContext));
            AddToCreationMethods<ICategoryRepository>(dataContext => new CategoryRepository(dataContext));
        }
        
    }
}