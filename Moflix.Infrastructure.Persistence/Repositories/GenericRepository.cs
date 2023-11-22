using Microsoft.EntityFrameworkCore;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Infrastructure.Persistence.Context;

namespace Moflix.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _dbcontext;

        public GenericRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _dbcontext.Set<Entity>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(Entity entity, int id)
        {
            var entry = await _dbcontext.Set<Entity>().FindAsync(id);
            _dbcontext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Entity entity)
        {
            _dbcontext.Set<Entity>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _dbcontext.Set<Entity>().ToListAsync();//Deferred execution
        }

        public virtual async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbcontext.Set<Entity>().AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Entity>().FindAsync(id);
        }
    }
}