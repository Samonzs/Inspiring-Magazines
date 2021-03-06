using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InspiringMagazine20056663Prac3.Models
{
    public class Customer
    {
       
        [Key, Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string email { get; set; }

        [Required(ErrorMessage = "Family Name is Required")]
        [RegularExpression(@"[a-zA-Z-']{2,20}$", ErrorMessage = "This magazine field needs to be between 2 and 20 alphabetic characters. hyphens and apostrophe's are permitted only")]
        public string familyName { get; set; }
        [Required(ErrorMessage = "Gives Name is Required")]
        [RegularExpression(@"[a-zA-Z-']{2,20}$", ErrorMessage = "This magazine field needs to be between 2 and 20 alphabetic characters. hyphens and apostrophe's are permitted only")]

        public string givenName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public string dateOfBirth { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [RegularExpression(@"^04([0-9]{2})[ ]([0-9]{3})[ ]([0-9]{3})", ErrorMessage = "This Mobile Number is not valid, a valid number indiciates a spaces after the first on 5th and 9th index")]

        public string mobileNumber { get; set; }
        [Required(ErrorMessage = "Post Code is Required")]
        [RegularExpression(@"[0-8]{1}[0-9]{3}", ErrorMessage = "This Post Code is not valid, first digit must not start with 9")]

        public string postalCode { get; set; }


        // Navigation properties
        public ICollection<Subscription> TheSubscriptions { get; set; }
    }
}