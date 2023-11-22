using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Domain.Entities;
using Moflix.Infrastructure.Persistence.Context;

namespace Moflix.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _dbcontext;

        public CategoryRepository(ApplicationContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}