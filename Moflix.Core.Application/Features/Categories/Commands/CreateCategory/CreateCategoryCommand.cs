using AutoMapper;
using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }
    }
}