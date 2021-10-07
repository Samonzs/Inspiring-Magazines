using InspiringMagazine20056663Prac3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace InspiringMagazine20056663Prac3.Pages.Subscriptions
{
    [Authorize(Roles = "customers")]

    public class IndexModel : PageModel
    {
        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public IndexModel(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Subscription> Subscription { get;set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder)
        {
     

            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "magazine_asc";
            }

            var subscription = (IQueryable<Subscription>)_context.Subscription;


            switch (sortOrder)
            {
                case "magazine_asc":
                    subscription = subscription.OrderBy(m => m.TheMagazine.magazineName);
                    break;
                case "magazine_desc":
                    subscription = subscription.OrderByDescending(m => m.TheMagazine.magazineName);
                    break;
                case "numOfIssues_asc":
                    subscription = subscription.OrderBy(m => m.numOfIssues);
                    break;
                case "numOfIssues_desc":
                    subscription = subscription.OrderByDescending(m => m.numOfIssues);
                    break;
                case "totalCost_asc":
                    subscription = subscription.OrderBy(m => m.TotalCost);
                    break;
                case "totalCost_desc":
                    subscription = subscription.OrderByDescending(m => m.TotalCost);
                    break;
            }

            ViewData["NextMagazine"] = sortOrder != "magazine_asc" ? "magazine_asc" : "magazine_desc";
            ViewData["NextNumOfIssues"] = sortOrder != "numOfIssues_asc" ? "numOfIssues_asc" : "numOfIssues_desc";
            ViewData["NextTotalCost"] = sortOrder != "totalCost_asc" ? "totalCost_asc" : "totalCost_desc";


            Subscription = await subscription.AsNoTracking()
                .Include(s => s.TheCustomer)
                .Include(s => s.TheMagazine).Where(a => a.customerEmail.Contains(User.FindFirst(ClaimTypes.Name).Value)).ToListAsync();

             
            return Page();

        }

    }
}
