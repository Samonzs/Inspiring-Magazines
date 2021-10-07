using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InspiringMagazine20056663Prac3.Models;
using Microsoft.AspNetCore.Authorization;


namespace InspiringMagazine20056663Prac3.Pages.Subscriptions
{
    [Authorize(Roles = "customers")]

    public class CalcSubscriptionStats__Model : PageModel
    {
        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public CalcSubscriptionStats__Model(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // For passing the results to the Content file
        public IList<CalcStatistic> SubscriptionStatistics { get; set; }

        // GET: Movies/CalcGenreStats
        public async Task<IActionResult> OnGetAsync()
        {
            // divide the movies into groups by genre
            var subscription = _context.Subscription.GroupBy(m => m.numOfIssues);

            // for each group, get its genre value and the number of movies in this group
            SubscriptionStatistics = await subscription.Select(g => new CalcStatistic { numOfIssues = g.Key, SubscriptionCount = g.Count() }).ToListAsync();

            return Page();
        }

        /*
        public void OnGet()
        {

        }
        */
    }
}