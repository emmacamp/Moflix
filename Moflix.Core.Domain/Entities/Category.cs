using Moflix.Core.Domain.Common;

namespace Moflix.Core.Domain.Entities
{
    public class Category : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movies>? Movies { get; set; }
    }
}