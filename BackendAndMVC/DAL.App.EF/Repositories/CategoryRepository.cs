using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain;
using ee.itcollege.akaver.Contracts.DAL.Base.Mappers;
using ee.itcollege.akaver.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, Category, AppDbContext>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new IdentityFunctionMapper())
        {
        }
    }
}