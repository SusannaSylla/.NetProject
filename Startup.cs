using System.Linq;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KooliProjekt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void
            ConfigureServices(
                IServiceCollection services) // This method gets called by the runtime (.net core 5). Use this method to add services to the container.
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            // services.AddControllersWithViews(); // initialise model-view-controller (MVC) pages
            // services.AddRazorPages(); // initialize generated CRUD pages
            
            services.AddMvc(); // this does both of the above - AddControllersWithViews() and AddRazorPages() 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // tell router to map the generated CRUD pages, so we can use them in pages
                endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
            });

            EnsureDatabase(app); // check if database exists, if not - create new and add test data
        }

        private void EnsureDatabase(IApplicationBuilder app)
        {
            // get service factory instance so we could get service scope
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            // get service scope instance, this is needed to get program services like database context to do stuff
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // created database file if none exists, returns boolean - was db deleted or not ?
                dbContext.Database.EnsureCreated();

                SeedDatabase(dbContext);
            }
        }

        private void SeedDatabase(ApplicationDbContext context)
        {
            // insert predefined authors
            var authors = new[]
            {
                new Author() { AuthorId = 1, FirstName = "Mihkel", LastName = "Männik", YearOfBirth = 1699 },
                new Author() { AuthorId = 2, FirstName = "Andres", LastName = "Ehin", YearOfBirth = 2008 },
                new Author() { AuthorId = 3, FirstName = "Peep", LastName = "Ehasalu", YearOfBirth = 1990 },
                new Author() { AuthorId = 4, FirstName = "Leelo", LastName = "Tungal", YearOfBirth = 1956 },
            };
            foreach (var author in authors)
            {
                if (!context.Authors.Any(l => l.AuthorId == author.AuthorId))
                {
                    context.Authors.Add(author);
                }
            }

            // insert predefined publishers
            var publishers = new[]
            {
                new Publisher() { PublisherId = 1, PublisherName = "ABC raamat" },
                new Publisher() { PublisherId = 2, PublisherName = "Kirjastus Veeremaa" },
                new Publisher() { PublisherId = 3, PublisherName = "Kirjastus koolibri" },
            };
            foreach (var publisher in publishers)
            {
                if (!context.Publishers.Any(l => l.PublisherId == publisher.PublisherId))
                {
                    context.Publishers.Add(publisher);
                }
            }

            // insert predefined books
            var books = new[]
            {
                new Book() { BookId = 1, BookTitle = "Don Quixote", PublisherId = 1 },
                new Book() { BookId = 2, BookTitle = "Tõde ja Õigus", PublisherId = 1 },
                new Book() { BookId = 3, BookTitle = "Kevade", PublisherId = 2 },
                new Book() { BookId = 4, BookTitle = "Viplala", PublisherId = 2 },
                new Book() { BookId = 5, BookTitle = "Pal Tänava Poisid", PublisherId = 3 },
            };
            foreach (var book in books)
            {
                if (!context.Books.Any(l => l.BookId == book.BookId))
                {
                    context.Books.Add(book);
                }
            }

            context.SaveChanges();

            // insert predefined book authors
            var bookAuthors = new[]
            {
                new BookAuthor() { BookAuthorId = 1, AuthorId = 1, BookId = 1 },
                new BookAuthor() { BookAuthorId = 2, AuthorId = 2, BookId = 1 },

                new BookAuthor() { BookAuthorId = 3, AuthorId = 1, BookId = 2 },
                new BookAuthor() { BookAuthorId = 4, AuthorId = 3, BookId = 2 },

                new BookAuthor() { BookAuthorId = 5, AuthorId = 3, BookId = 3 },
                new BookAuthor() { BookAuthorId = 6, AuthorId = 3, BookId = 4 },

                new BookAuthor() { BookAuthorId = 7, AuthorId = 2, BookId = 5 },
                new BookAuthor() { BookAuthorId = 8, AuthorId = 3, BookId = 5 },
            };
            foreach (var bookAuthor in bookAuthors)
            {
                if (!context.BookAuthors.Any(l => l.BookAuthorId == bookAuthor.BookAuthorId))
                {
                    context.BookAuthors.Add(bookAuthor);
                }
            }

            context.SaveChanges();

            // insert predefined Comments
            var comments = new[]
            {
                new Comment() { CommentId = 1, BookId = 1, CommentText = "Best book ever!" },
                new Comment() { CommentId = 2, BookId = 2, CommentText = "Very interesting book" },
                new Comment() { CommentId = 3, BookId = 3, CommentText = "Very stunning" },
            };
            foreach (var comment in comments)
            {
                if (!context.Comments.Any(l => l.CommentId == comment.CommentId))
                {
                    context.Comments.Add(comment);
                }
            }

            context.SaveChanges();
        }
    }
}