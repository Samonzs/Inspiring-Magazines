using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using InspiringMagazine20056663Prac3.Models;

namespace InspiringMagazine20056663Prac3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InspiringMagazine20056663Prac3.Models.Customer> Customer { get; set; }
        public DbSet<InspiringMagazine20056663Prac3.Models.Magazine> Magazine { get; set; }
        public DbSet<InspiringMagazine20056663Prac3.Models.Subscription> Subscription { get; set; }
    }
}
