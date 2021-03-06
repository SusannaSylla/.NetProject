using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Pages.BookAuthors
{
    public class DetailsModel : PageModel
    {
        private readonly KooliProjekt.Data.ApplicationDbContext _context;

        public DetailsModel(KooliProjekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public BookAuthor BookAuthor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookAuthor = await _context.BookAuthors
                .Include(b => b.Author)
                .Include(b => b.Book).FirstOrDefaultAsync(m => m.BookAuthorId == id);

            if (BookAuthor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
