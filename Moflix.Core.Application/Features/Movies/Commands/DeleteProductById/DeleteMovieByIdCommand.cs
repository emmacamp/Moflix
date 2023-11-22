using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;

namespace Moflix.Core.Application.Features.Moviesf.Commands.DeleteProductById
{
    public class DeleteMovieByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteMovieByIdCommand, int>
    {
        private readonly IMoviesRepository _moviesRepository;

        public DeleteProductByIdCommandHandler(IMoviesRepository productRepository)
        {
            _moviesRepository = productRepository;
        }

        public async Task<int> Handle(DeleteMovieByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _moviesRepository.GetByIdAsync(command.Id);

            if (product == null) throw new Exception("Products not found");

            await _moviesRepository.DeleteAsync(product);

            return product.Id;
        }
    }
}