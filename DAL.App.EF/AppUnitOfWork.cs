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

        public IAuthorRepository Authors => _repositoryProvider.GetRepository<IAuthorRepository>();
        public IBookAndAuthorRepository BookAndAuthors => _repositoryProvider.GetRepository<IBookAndAuthorRepository>();
        public IBookRepository Books => _repositoryProvider.GetRepository<IBookRepository>();
        public ICommentRepository Comments => _repositoryProvider.GetRepository<ICommentRepository>();
        public IPublisherRepository Publishers => _repositoryProvider.GetRepository<IPublisherRepository>();
    }
}