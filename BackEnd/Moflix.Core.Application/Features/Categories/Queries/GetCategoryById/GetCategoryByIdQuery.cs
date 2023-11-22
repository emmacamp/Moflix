using AutoMapper;
using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.ViewModels.Categories;

namespace Moflix.Core.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryViewModel>
    {
        public int Id { get; set; }
    }

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllWithIncludeAsync(new List<string> { "Products" });
            var category = categories.FirstOrDefault(w => w.Id == query.Id);
            if (category == null) throw new Exception($"Category Not Found.");
            var categoryVm = _mapper.Map<CategoryViewModel>(category);
            categoryVm.ProductsQuantity = category.Movies.Count;
            return categoryVm;
        }
    }
}