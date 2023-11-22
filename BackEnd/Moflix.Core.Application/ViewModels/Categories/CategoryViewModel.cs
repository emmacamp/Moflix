using Moflix.Core.Application.ViewModels.Movies;

namespace Moflix.Core.Application.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<MoviesViewModel>? Products { get; set; }
        public int ProductsQuantity { get; set; }
    }
}