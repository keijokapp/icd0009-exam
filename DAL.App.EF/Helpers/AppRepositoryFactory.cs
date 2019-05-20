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
            AddToCreationMethods<IAuthorRepository>(dataContext => new AuthorRepository(dataContext));
            AddToCreationMethods<IBookRepository>(dataContext => new BookRepository(dataContext));
            AddToCreationMethods<IBookAndAuthorRepository>(dataContext => new BookAndAuthorRepository(dataContext));
            AddToCreationMethods<ICommentRepository>(dataContext => new CommentRepository(dataContext));
            AddToCreationMethods<IPublisherRepository>(dataContext => new PublisherRepository(dataContext));
        }
        
    }
}