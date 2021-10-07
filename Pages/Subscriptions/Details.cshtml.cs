using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InspiringMagazine20056663Prac3.Data;
using InspiringMagazine20056663Prac3.Models;

namespace InspiringMagazine20056663Prac3.Pages.Subscriptions
{
    public class DetailsModel : PageModel
    {
        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public DetailsModel(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Subscription Subscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subscription = await _context.Subscription
                .Include(s => s.TheCustomer)
                .Include(s => s.TheMagazine).FirstOrDefaultAsync(m => m.ID == id);

            if (Subscription == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
