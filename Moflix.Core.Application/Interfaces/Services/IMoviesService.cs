using Moflix.Core.Application.ViewModels.Movies;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Interfaces.Services
{
    public interface IMoviesService : IGenericService<SaveMoviesViewModel, MoviesViewModel, Movies>
    {
        Task<List<MoviesViewModel>> GetAllViewModelWithFilters(FilterMovieViewModel filters);

        Task<List<MoviesViewModel>> GetAllViewModelWithInclude();
    }
}