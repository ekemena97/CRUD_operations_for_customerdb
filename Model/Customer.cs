using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Model
{
    [Table("Customer_tbl")]

    public class Customer
    {
        
     [Key]
        public int CustomerID { get; set; }

        [Required]

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage ="Invalid Length")]

        public string PhoneNumber { get; set; }

        public List<Order> Orders { get; set; }
    
    }
}
