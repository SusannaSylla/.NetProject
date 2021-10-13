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
    public class DeleteModel : PageModel
    {
        private readonly KooliProjekt.Data.ApplicationDbContext _context;

        public DeleteModel(KooliProjekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookAuthor = await _context.BookAuthors.FindAsync(id);

            if (BookAuthor != null)
            {
                _context.BookAuthors.Remove(BookAuthor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
