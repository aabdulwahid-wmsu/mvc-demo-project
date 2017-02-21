using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyzMVC.Dal
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int? age { get; set; }
        public String Gender { get; set; }
    }
}
