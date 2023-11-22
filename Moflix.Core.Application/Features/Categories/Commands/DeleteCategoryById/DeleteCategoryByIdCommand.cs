using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;

namespace Moflix.Core.Application.Features.Categories.Commands.DeleteCategoryById
{
    public class DeleteCategoryByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryByIdCommandHandler : IRequestHandler<DeleteCategoryByIdCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryByIdCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(DeleteCategoryByIdCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.Id);
            if (category == null) throw new Exception($"Category Not Found.");
            await _categoryRepository.DeleteAsync(category);
            return category.Id;
        }
    }
}