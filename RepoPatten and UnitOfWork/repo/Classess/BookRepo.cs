using RepoPatten_and_UnitOfWork.DB;
using RepoPatten_and_UnitOfWork.Model;
using RepoPatten_and_UnitOfWork.repo.Interfaces;

namespace RepoPatten_and_UnitOfWork.repo.Classess
{
    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        private readonly AppDbContext context;

        public BookRepo( AppDbContext context ) : base( context )
        {
        }

        public IEnumerable<Book> Special()
        {
            throw new NotImplementedException();
        }
    }
}
