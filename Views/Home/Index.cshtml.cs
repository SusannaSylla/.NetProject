using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KooliProjekt.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        private readonly KooliProjekt.Data.ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, KooliProjekt.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public void OnGet()
        {
        }
    }
}