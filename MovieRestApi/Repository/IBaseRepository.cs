using MovieRestApi.Models;
using System.Linq.Expressions;
using System.Security.Principal;

namespace MovieRestApi.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        Task Update(T entity, Guid id);
        Task Delete(Guid id);
    }
}
