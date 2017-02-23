using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyzMVC.Dal
{
    [Table("Education")]
    public class Education
    {   
        
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public String School { get; set; }
        public String YearAttended { get; set; }

        public User Users { get; set; }
    }
}
