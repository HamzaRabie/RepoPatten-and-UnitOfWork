using System.Linq.Expressions;
using RepoPatten_and_UnitOfWork.Const;

namespace RepoPatten_and_UnitOfWork.repo.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        //crud 

        //r 
        T GetById(int id);
        IEnumerable<T> GetAll();
        T GetOneWithInclude(Expression<Func<T , bool>> criteria , string[] includes = null);
        IEnumerable<T> GetAllWithInclude( string[] includes = null);

        //c 
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        //d 
        void Delete(T entity);

        //u
        T Update(T entity);

        //// logics ///

        IEnumerable<T> Order(Expression<Func<T, object>> orderBy, string orderByDirection = OrderDir.Assending
            , string[] includes = null
            );

    }
}
