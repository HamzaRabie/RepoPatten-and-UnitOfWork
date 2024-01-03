using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using RepoPatten_and_UnitOfWork.Const;
using RepoPatten_and_UnitOfWork.DB;
using RepoPatten_and_UnitOfWork.repo.Interfaces;
using System.Linq.Expressions;

namespace RepoPatten_and_UnitOfWork.repo.Classess
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly AppDbContext context;

        public BaseRepo( AppDbContext context )
        {
            this.context = context;
        }

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
            return entities;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            context.Update(entity);
            return entity;
        }


        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }


        public T GetOneWithInclude(Expression<Func<T,bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = context.Set<T>();
            if (includes != null)
            {
                foreach(var include in includes)
                    query = query.Include(include);
            }

            return query.SingleOrDefault(criteria);
        }

        public IEnumerable<T> GetAllWithInclude(string[] includes = null)
        {
            IQueryable<T> query = context.Set<T>();
            if( includes != null)
            {
                foreach( var include in includes)
                   query= query.Include(include);
            }
            return query.ToList();

        }

       public IEnumerable<T> Order(Expression<Func<T, object>> orderBy, string orderByDirection = OrderDir.Assending
           , string[] includes = null)
        {
            IQueryable<T> query = context.Set<T>();
            if(includes != null)
            {
                foreach(var include in includes)
                    query = query.Include(include);
            }
            if( orderByDirection == OrderDir.Assending )
                return query.OrderBy(orderBy);
            else 
                return query.OrderByDescending(orderBy);

        }
           


    }
}
