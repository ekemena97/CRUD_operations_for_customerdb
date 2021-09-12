using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=CustomerConnection")
        {

        }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Order> Orders { get; set; }
    }
}
