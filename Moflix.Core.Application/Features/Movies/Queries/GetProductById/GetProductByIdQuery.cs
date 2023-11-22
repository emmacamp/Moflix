using AutoMapper;
using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.ViewModels.Categories;
using Moflix.Core.Application.ViewModels.Movies;

namespace Moflix.Core.Application.Features.Moviesf.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<MoviesViewModel>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHadler : IRequestHandler<GetProductByIdQuery, MoviesViewModel>
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHadler(IMoviesRepository productRepository, IMapper mapper)
        {
            _moviesRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<MoviesViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await GetByIdViewModel(request.Id);
            if (product == null) throw new Exception("Products not found");
            return product;
        }

        private async Task<MoviesViewModel> GetByIdViewModel(int id)
        {
            var productList = await _moviesRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            var movie = productList.FirstOrDefault(f => f.Id == id);

            MoviesViewModel productVm = new()
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
            };

            return productVm;
        }
    }
}