using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AyzMVC.Areas.Security.Models
{
    public class UserViewModel
    {
        public int id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [MinLength(3, ErrorMessage="Minimum of 3 characters")]
        [MaxLength(25, ErrorMessage="Maximum of 25 characters")]
        
        public String FirstName { get; set; }

        [Required,Display(Name = "Family Name")]
        [MinLength(3, ErrorMessage = "Minimum of 3 characters")]
        [MaxLength(25, ErrorMessage = "Maximum of 25 characters")]
        public String LastName { get; set; }

        [Display(Name = "Age")]
        public int? age { get; set; }

        public String Gender { get; set; }
        [Display(Name = "Employment Date")]
        public DateTime? EmploymentDate { get; set; }
        public int UserID { get; set; }
        public String School { get; set; }
        [Display(Name = "Year Attended")]
        public String YearAttended { get; set; }

    }
}