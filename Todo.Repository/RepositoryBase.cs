using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Todo.Contracts;
using Todo.Entities;

namespace Todo.Repository
{
    public abstract class RepositoryBase<T>(RepositoryContext repositoryContext) : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; } = repositoryContext;

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
