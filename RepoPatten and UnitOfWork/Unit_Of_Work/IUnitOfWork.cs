using RepoPatten_and_UnitOfWork.Model;
using RepoPatten_and_UnitOfWork.repo.Interfaces;

namespace RepoPatten_and_UnitOfWork.Unit_Of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepo<Author> Auhtors {  get; }
        IBookRepo books { get; }

        int complete();

    }
}
