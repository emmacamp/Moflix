using AutoMapper;
using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.ViewModels.Categories;
using Moflix.Core.Application.ViewModels.Movies;

namespace Moflix.Core.Application.Features.Moviesf.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IList<MoviesViewModel>>
    {
        public int? CategoryId { get; set; }
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<MoviesViewModel>>
    {
        private readonly IMoviesRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IMoviesRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<MoviesViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var filter = _mapper.Map<GetAllProductsParameter>(request);
            var productList = await GetAllViewModelWithFilters(filter);
            if (productList == null || productList.Count == 0) throw new Exception("Movie not found");
            return productList;
        }

        private async Task<List<MoviesViewModel>> GetAllViewModelWithFilters(GetAllProductsParameter filters)
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            var listViewModels = productList.Select(movie => new MoviesViewModel
            {
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                Id = movie.Id,
                Actors = movie.Actors,
                Src = movie.Cover,
                CategoryName = movie.Category.Name,
                CategoryId = movie.Category.Id,
                CategoryWithoutProduct = _mapper.Map<CategoryWithoutProductsViewModel>(movie.Category),
                Year = movie.Year,
                Director = movie.Director
            }).ToList();

            if (filters.CategoryId != null)
            {
                listViewModels = listViewModels.Where(movie => movie.CategoryId == filters.CategoryId.Value).ToList();
            }

            return listViewModels;
        }
    }
}