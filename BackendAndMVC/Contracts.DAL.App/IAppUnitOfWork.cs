using System;
using Contracts.DAL.App.Repositories;
using ee.itcollege.akaver.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookAndAuthorRepository BookAndAuthors { get; }
        IBookRepository Books { get; }
        ICommentRepository Comments { get; }
        IPublisherRepository Publishers { get; }
        
    }
}