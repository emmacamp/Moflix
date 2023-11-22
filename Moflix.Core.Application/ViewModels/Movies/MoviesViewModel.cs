using Moflix.Core.Application.ViewModels.Categories;

namespace Moflix.Core.Application.ViewModels.Movies
{
    public class MoviesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public string Src { get; set; }
        public string Cover { get; set; }
        public string Actors { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        public CategoryWithoutProductsViewModel? CategoryWithoutProduct { get; set; }
        public CategoryViewModel? Category { get; set; }
    }
}