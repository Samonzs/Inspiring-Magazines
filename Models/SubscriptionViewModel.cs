using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace InspiringMagazine20056663Prac3.Models
{
    public class SubscriptionViewModel
    {
        public int magazineID { get; set; }
        public string customerEmail { get; set; }

        [Range(1, 80)]
        public int numOfIssues { get; set; }

       
    }
}
