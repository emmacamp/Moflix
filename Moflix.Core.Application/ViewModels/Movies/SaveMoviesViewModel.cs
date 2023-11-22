using Microsoft.AspNetCore.Http;
using Moflix.Core.Application.ViewModels.Categories;
using System.ComponentModel.DataAnnotations;

namespace Moflix.Core.Application.ViewModels.Movies
{
    public class SaveMoviesViewModel
    {
        [Required(ErrorMessage = "At least one actor is required.")]
        public string Actors { get; set; }

        public List<CategoryViewModel>? Categories { get; set; }


        [Required(ErrorMessage = "The Category field is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Cover field is required.")]
        [Url(ErrorMessage = "The Cover field must be a valid URL.")]
        public string Cover { get; set; }

        [Required(ErrorMessage = "The Director field is required.")]
        [StringLength(50, ErrorMessage = "The Director must be at most 50 characters long.")]
        public string Director { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "The Src field is required.")]
        [Url(ErrorMessage = "The Src field must be a valid URL.")]
        public string Src { get; set; }

        [Required(ErrorMessage = "The Synopsis field is required.")]
        [MaxLength(500, ErrorMessage = "The Synopsis must be at most 500 characters long.")]
        public string Synopsis { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "The Title must be at most 100 characters long.")]
        public string Title { get; set; }

        public string? UserId { get; set; }

        [Range(1900, 2100, ErrorMessage = "The Year must be between 1900 and 2100.")]
        public int Year { get; set; }
    }
}