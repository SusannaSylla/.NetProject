using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [MaxLength(128)] [MinLength(1)] public string PublisherName { get; set; } = default!;

        public ICollection<Book>? Books { get; set; }
    }
}