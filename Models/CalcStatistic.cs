using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InspiringMagazine20056663Prac3.Models
{
    public class CalcStatistic
    {
        [Display(Name = "Number Of Issues")]
        public int numOfIssues { get; set; }

        [Display(Name = "Subscription Count")]
        public int SubscriptionCount { get; set; }

    }
}