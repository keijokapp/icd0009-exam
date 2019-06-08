using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.akaver.Contracts.DAL.Base.Helpers;
using ee.itcollege.akaver.DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext dataContext, IBaseRepositoryProvider repositoryProvider) : base(dataContext,
            repositoryProvider)
        {
        }

        public IProductRepository Products => _repositoryProvider.GetRepository<IProductRepository>();
        public IOrderRepository Orders => _repositoryProvider.GetRepository<IOrderRepository>();
        public IOrderLineRepository OrderLines => _repositoryProvider.GetRepository<IOrderLineRepository>();
        public IOrderLineAdditionRepository OrderLineAdditions => _repositoryProvider.GetRepository<IOrderLineAdditionRepository>();
        public ICategoryRepository Categories => _repositoryProvider.GetRepository<ICategoryRepository>();
    }
}