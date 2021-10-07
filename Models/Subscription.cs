using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InspiringMagazine20056663Prac3.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public int magazineID { get; set; }
        public string customerEmail { get; set; }

        [Display(Name = "Number of Issues")]
        [Range(1, 80)]
        public int numOfIssues { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }
        
        [Display(Name = "Magazine")]
        public Magazine TheMagazine { get; set; }
        
        [Display(Name = "Customer")]
        public Customer TheCustomer { get; set; }
    }
}