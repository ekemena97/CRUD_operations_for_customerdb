using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Model
{
    public class Order
    {
        [Key]

        public int OrderId { get; set; }

        public string OrderDisplayNumber { get; set; }

        public string ItemCount { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool IsFufilled { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]

        public Customer customer { get; set; }

    }
}
