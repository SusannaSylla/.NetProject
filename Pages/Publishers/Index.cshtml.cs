using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly KooliProjekt.Data.ApplicationDbContext _context;

        public IndexModel(KooliProjekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publishers.ToListAsync();
        }
    }
}
