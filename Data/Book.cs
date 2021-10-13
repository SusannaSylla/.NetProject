using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Book
    {
        public int BookId { get; set; }

        [MaxLength(128)]
        [MinLength(1)]
        public string BookTitle { get; set; }  = default!;

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public ICollection<Comment>? Comments { get; set; }  
    }
}