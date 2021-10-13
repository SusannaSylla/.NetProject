using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KooliProjekt.Data;

namespace KooliProjekt.Pages.BookAuthors
{
    public class CreateModel : PageModel
    {
        private readonly KooliProjekt.Data.ApplicationDbContext _context;

        public CreateModel(KooliProjekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId");
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            return Page();
        }

        [BindProperty]
        public BookAuthor BookAuthor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookAuthors.Add(BookAuthor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
