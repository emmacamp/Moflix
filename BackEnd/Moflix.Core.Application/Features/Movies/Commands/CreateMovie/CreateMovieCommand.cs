using AutoMapper;
using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.ViewModels.Categories;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Features.Moviesf.Commands.CreateProduct
{
    public class CreateMovieCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public string Src { get; set; }
        public string Cover { get; set; }
        public string Actors { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMoviesRepository productRepository, IMapper mapper)
        {
            _moviesRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Movies>(command);
            product = await _moviesRepository.AddAsync(product);
            return product.Id;
        }
    }
}