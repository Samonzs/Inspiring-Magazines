using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InspiringMagazine20056663Prac3.Data;
using InspiringMagazine20056663Prac3.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;



namespace InspiringMagazine20056663Prac3.Pages.Subscriptions
{
    [Authorize(Roles = "customers")]

    public class CreateModel : PageModel
    {

        private readonly InspiringMagazine20056663Prac3.Data.ApplicationDbContext _context;

        public CreateModel(InspiringMagazine20056663Prac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {     
            ViewData["customerEmail"] = new SelectList(_context.Customer, "email", "email");
            ViewData["magazineID"] = new SelectList(_context.Magazine, "magazineID", "magazineName");
            return Page();
        }

        [BindProperty]
        public SubscriptionViewModel SubscriptionInput { get; set; }

        public Subscription Subscription { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Subscription = await _context.Subscription
                .Include(s => s.TheCustomer)
                .Include(s => s.TheMagazine).FirstOrDefaultAsync();


            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Finding Logged in User
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            if (string.IsNullOrWhiteSpace(_email))
            {
                return NotFound();
            }

            // creating an order object for inserting into database
            Subscription subscription = new Subscription();
            // Construct this Order object based on OrderInput
            subscription.magazineID = SubscriptionInput.magazineID;
            subscription.numOfIssues = SubscriptionInput.numOfIssues;
            subscription.customerEmail = _email;

            // retrieve the ordered movie to get its price
            var theMagazine = await _context.Magazine.FindAsync(SubscriptionInput.magazineID);
            // calculate the total price of this order

            ViewData["Total"] = subscription.TotalCost = SubscriptionInput.numOfIssues * theMagazine.Price;
            ViewData["NoOfIssues"] = subscription.numOfIssues;
            ViewData["MagazineName"] = theMagazine.magazineName;


            _context.Subscription.Add(subscription);
            await _context.SaveChangesAsync();

            ViewData["SuccessDB"] = "success";


            return Page();

        }
    }
}