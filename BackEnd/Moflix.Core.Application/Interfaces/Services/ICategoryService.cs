using Moflix.Core.Application.ViewModels.Categories;
using Moflix.Core.Domain.Entities;

namespace Moflix.Core.Application.Interfaces.Services
{
    public interface ICategoryService : IGenericService<SaveCategoryViewModel, CategoryViewModel, Category>
    {
        Task<List<CategoryViewModel>> GetAllViewModelWithInclude();
    }
}