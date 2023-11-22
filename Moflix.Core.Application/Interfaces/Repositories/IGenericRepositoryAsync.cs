namespace Moflix.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);

        Task DeleteAsync(Entity entiy);

        Task<List<Entity>> GetAllAsync();

        Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);

        Task<Entity> GetByIdAsync(int id);

        Task UpdateAsync(Entity entity, int id);
    }
}