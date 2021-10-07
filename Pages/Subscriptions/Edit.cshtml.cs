using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InspiringMagazine20056663Prac3.Data;
using InspiringMagazine20056663Prac3.Models;

namespace InspiringMagazine20056663Prac3.Pages.Subscriptions
{
    public class EditModel : PageModel
    {
        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public EditModel(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["customerEmail"] = new SelectList(_context.Customer, "email", "email");
           ViewData["magazineID"] = new SelectList(_context.Magazine, "magazineID", "magazineName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(Subscription.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscription.Any(e => e.ID == id);
        }
    }
}
