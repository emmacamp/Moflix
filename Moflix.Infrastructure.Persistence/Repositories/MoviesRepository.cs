using Moflix.Infrastructure.Persistence.Context;
using Moflix.Core.Domain.Entities;
using Moflix.Core.Application.Interfaces.Repositories;

namespace Moflix.Infrastructure.Persistence.Repositories
{
    public class MoviesRepository : GenericRepository<Movies>, IMoviesRepository
    {
        private readonly ApplicationContext _dbContext;

        public MoviesRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}