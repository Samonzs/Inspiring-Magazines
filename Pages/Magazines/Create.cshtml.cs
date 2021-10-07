using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InspiringMagazine20056663Prac3.Data;
using InspiringMagazine20056663Prac3.Models;

namespace InspiringMagazine20056663Prac3.Pages.Magazines
{
    public class CreateModel : PageModel
    {
        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public CreateModel(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Magazine Magazine { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Magazine.Add(Magazine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
