using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.ViewModels.Categories;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Features.Moviesf.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductUpdateResponse>
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

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductUpdateResponse>
    {

        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMoviesRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _moviesRepository = productRepository;
            _mapper = mapper;
            

        }

        public async Task<ProductUpdateResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {

            var movies = await _moviesRepository.GetByIdAsync(command.Id);

            if (movies == null) throw new Exception("Products not found");

            // Actualizar propiedades individuales en lugar de sobrescribir toda la instancia
            movies = _mapper.Map<Movies>(command);

            await _moviesRepository.UpdateAsync(movies, movies.Id);

            var productResponse = _mapper.Map<ProductUpdateResponse>(movies);

            return productResponse;
        }
    }
}