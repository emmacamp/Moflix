using AutoMapper;
using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryUpdateResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryUpdateResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryUpdateResponse> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.Id);

            if (category == null)
            {
                throw new Exception($"Category Not Found.");
            }
            else
            {
                category = _mapper.Map<Category>(command);
                await _categoryRepository.UpdateAsync(category, category.Id);
                var categoryVm = _mapper.Map<CategoryUpdateResponse>(category);

                return categoryVm;
            }
        }
    }
}