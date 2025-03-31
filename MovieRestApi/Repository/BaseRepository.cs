using Microsoft.EntityFrameworkCore;
using MovieRestApi.Models;
using System.Linq.Expressions;
using System.Security.Principal;

namespace MovieRestApi.Repository
{
   
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
       where TEntity : BaseEntity, new()
    {
        private readonly DbContext _context;
        public BaseRepository(MainDbContext context)
        {
            _context = context;
        }
        public async Task Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid Id)
        {
            var entity = Get(x=> x.Id == Id);
            if (entity == null)
            {
                throw new Exception("Verilen Id'ye göre entity bulunmadı!");
            }

            entity.İsDeleted = true;
            entity.DeletedAt = DateTime.Now;
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task Update(TEntity entity, Guid id)
        {
            var updatedEntity = _context.Set<TEntity>().Find(id);
            entity.UpdatedAt = DateTime.Now;

            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }
    }
}
