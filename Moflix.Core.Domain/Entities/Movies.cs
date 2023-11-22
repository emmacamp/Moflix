using Moflix.Core.Domain.Common;

namespace Moflix.Core.Domain.Entities
{
    public class Movies : AuditableBaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public string Cover { get; set; }
        public string Actors { get; set; }
        public int CategoryId { get; set; }

        //Navigation Property
        public Category? Category { get; set; }

        public string? UserId { get; set; }
    }
}