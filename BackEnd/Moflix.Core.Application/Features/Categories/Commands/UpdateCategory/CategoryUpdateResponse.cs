namespace Moflix.Core.Application.Features.Categories.Commands.UpdateCategory
{
    public class CategoryUpdateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}