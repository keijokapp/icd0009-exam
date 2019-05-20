using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain;
using ee.itcollege.akaver.Contracts.DAL.Base.Mappers;
using ee.itcollege.akaver.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class CommentRepository : BaseRepository<Comment, Comment, AppDbContext>, ICommentRepository
    {
        public CommentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext,
            new IdentityFunctionMapper())
        {
        }
    }
}