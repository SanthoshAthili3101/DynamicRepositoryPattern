using System.Linq.Expressions;
using System.Security.Principal;

namespace DynamicRepositoryPattern.GenericDbContext
{
    public interface IEfRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetAll();
    }

}
