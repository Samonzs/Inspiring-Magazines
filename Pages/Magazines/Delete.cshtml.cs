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
    public class DeleteModel : PageModel
    {
        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public DeleteModel(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Magazine Magazine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Magazine = await _context.Magazine.FirstOrDefaultAsync(m => m.magazineID == id);

            if (Magazine == null)
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

            Magazine = await _context.Magazine.FindAsync(id);

            if (Magazine != null)
            {
                _context.Magazine.Remove(Magazine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
