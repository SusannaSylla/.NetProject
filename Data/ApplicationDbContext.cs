using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<BookAuthor> BookAuthors { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
        public DbSet<Publisher> Publishers { get; set; } = default!;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}