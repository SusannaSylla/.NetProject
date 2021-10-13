using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Pages.Comments
{
    public class DetailsModel : PageModel
    {
        private readonly KooliProjekt.Data.ApplicationDbContext _context;

        public DetailsModel(KooliProjekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _context.Comments
                .Include(c => c.Book).FirstOrDefaultAsync(m => m.CommentId == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
