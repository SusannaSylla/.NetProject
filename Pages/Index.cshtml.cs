using System.Collections.Generic;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly KooliProjekt.Data.ApplicationDbContext _context;

        public IList<Book> Book { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger, KooliProjekt.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors)
                .ThenInclude(b => b.Author)
                .Include(b => b.Comments)
                .ToListAsync();
        }
    }
}