using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moflix.Core.Application.DTOs.Account;
using Moflix.Core.Application.Helpers;
using Moflix.Core.Application.Interfaces.Repositories;
using Moflix.Core.Application.Interfaces.Services;
using Moflix.Core.Application.ViewModels.Categories;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Services
{
    public class CategoryService : GenericService<SaveCategoryViewModel, CategoryViewModel, Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponse userViewModel;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<List<CategoryViewModel>> GetAllViewModelWithInclude()
        {
            var categoryList = await _categoryRepository.GetAllWithIncludeAsync(new List<string> { "Products" });

            return categoryList.Select(category => new CategoryViewModel
            {
                Name = category.Name,
                Description = category.Description,
                Id = category.Id,
                ProductsQuantity = userViewModel != null ? category.Movies.Where(product => product.UserId == userViewModel.Id).Count() : category.Movies.Count()
            }).ToList();
        }
    }
}