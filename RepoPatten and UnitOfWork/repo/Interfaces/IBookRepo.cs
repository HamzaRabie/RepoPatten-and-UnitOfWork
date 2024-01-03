using RepoPatten_and_UnitOfWork.Model;
using System.Linq.Expressions;

namespace RepoPatten_and_UnitOfWork.repo.Interfaces
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        IEnumerable<Book> Special();
    }
}
