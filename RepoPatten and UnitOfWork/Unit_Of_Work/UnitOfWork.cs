using RepoPatten_and_UnitOfWork.DB;
using RepoPatten_and_UnitOfWork.Model;
using RepoPatten_and_UnitOfWork.repo.Classess;
using RepoPatten_and_UnitOfWork.repo.Interfaces;

namespace RepoPatten_and_UnitOfWork.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepo<Author> Auhtors { get; private set; }
        public IBookRepo books { get; private set; }

        private readonly AppDbContext context;

        public UnitOfWork( AppDbContext context )
        {
            this.context = context;
            Auhtors = new BaseRepo<Author>(context);
            books = new BookRepo(context);

        }

        public int complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
