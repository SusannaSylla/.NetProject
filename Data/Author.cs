using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Author
    {
        public int AuthorId { get; set; }

        [MaxLength(128)] [MinLength(1)] public string FirstName { get; set; } = default!;

        [MaxLength(128)] [MinLength(1)] public string LastName { get; set; } = default!;

        public int YearOfBirth { get; set; } = default!;

        public ICollection<BookAuthor>? AuthorBooks { get; set; }


        public string FirstLastName => FirstName + " " + LastName;
    }
}