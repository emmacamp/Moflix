using AutoMapper;
using MediatR;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.ViewModels.Categories;

namespace Moflix.Core.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>>
    {
    }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesViewModel = await GetAllViewModelWithInclude();
            return categoriesViewModel;
        }

        private async Task<List<CategoryViewModel>> GetAllViewModelWithInclude()
        {
            var categoryList = await _categoryRepository.GetAllWithIncludeAsync(new List<string> { "Movies" });

            return categoryList.Select(category => new CategoryViewModel
            {
                Name = category.Name,
                Description = category.Description,
                Id = category.Id,
                ProductsQuantity = category.Movies.Count
            }).ToList();
        }
    }
}