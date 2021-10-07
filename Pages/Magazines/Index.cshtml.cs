using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InspiringMagazine20056663Prac3.Data;
using InspiringMagazine20056663Prac3.Models;

namespace InspiringMagazine20056663Prac3.Pages.Magazines
{
    public class IndexModel : PageModel
    {
        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public IndexModel(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Magazine> Magazine { get;set; }

        public async Task OnGetAsync()
        {
            Magazine = await _context.Magazine.ToListAsync();
        }
    }
}
