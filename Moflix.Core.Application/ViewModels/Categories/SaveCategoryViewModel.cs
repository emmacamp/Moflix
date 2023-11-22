using System.ComponentModel.DataAnnotations;

namespace Moflix.Core.Application.ViewModels.Categories
{
    public class SaveCategoryViewModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(50, ErrorMessage = "The Name must be at most 50 characters long.")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "The Description must be at most 200 characters long.")]
        public string Description { get; set; }
    }
}