using Contracts.DAL.App.Repositories;
using ee.itcollege.akaver.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderLineRepository OrderLines { get; }
        IOrderLineAdditionRepository OrderLineAdditions { get; }
    }
}