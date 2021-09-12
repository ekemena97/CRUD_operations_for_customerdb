using ConsoleApp4.Data;
using ConsoleApp4.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Service
{
    class CustomerOperations
    {
        public bool SaveCustomer()
        {
            Console.WriteLine("Enter Company's Name: ");
            var custName = Console.ReadLine();

            Console.WriteLine("Enter Customer's Address: ");
            var custAdd = Console.ReadLine();

            Console.WriteLine("Enter Customer's Age: ");
            var custAgestring = Console.ReadLine();
            int.TryParse(custAgestring, out int custAge);

            Console.WriteLine("Enter Customer's Phone Number: ");
            var custPhone = Console.ReadLine();


            var customer = new Customer()
            {

                CompanyName = custName,
                Address = custAdd,
                Age = custAge,
                PhoneNumber = custPhone
            };

            try
            {
                using (var context = new CustomerContext())
                {
                    context.Customers.Add(customer);

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            try
            {
                using (var context = new CustomerContext())
                {
                    //LINQ METHOD
                    customers = context.Customers.ToList();

                    ////LINQ QUERY
                    //var query = from customer in context.Customers
                    //            select customer;
                    //customers = query.ToList();

                    ////NATIVE SQL
                    //customers = context.Customers.SqlQuery("select * from [TSQL2012].[Sales].[Customers]").ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return customers;
        }

        public List<Customer> GetAllCustomersByCountry(string phoneNumber)
        {
            var customers = new List<Customer>();
            try
            {
                using (var context = new CustomerContext())
                {
                    //LINQ METHOD
                    customers = context.Customers.Where(x => x.PhoneNumber == phoneNumber).ToList();

                    ////LINQ QUERY
                    //var query = from customer in context.Customers
                    //            where customer.country == country
                    //            select customer;
                    //customers = query.ToList();

                    ////NATIVE SQL
                    //customers = context.Customers.SqlQuery($"select * from [TSQL2012].[Sales].[Customers] where country = '{country}'").ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = new Customer();
            try
            {
                //using (var context = new MarketDBEntities())
                using (var context = new CustomerContext())
                {
                    //LINQ METHOD
                    customer = context.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                    ////LINQ QUERY
                    //var query = from cust in context.Customers
                    //            where cust.CustomerID == customerId
                    //            select cust;
                    //customer = query.FirstOrDefault();

                    ////NATIVE SQL
                    // customer = context.Customers.SqlQuery($"select * from [TSQL2012].[Sales].[Customers] where custid = {customerId}").FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return customer;
        }

        public bool UpdateCustomer(int customerId)
        {
            try
            {
                using (var context = new CustomerContext())
                {

                    Console.WriteLine("Enter Customer's New Address: ");
                    var custAdd = Console.ReadLine();

                    Console.WriteLine("Enter Customer's New Phone Number: ");
                    var custPhone = Console.ReadLine();

                    var customer = context.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                    customer.Address = custAdd;

                    customer.PhoneNumber = custPhone;

                    context.Entry(customer).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Customer DeleteCustomer(int customerId, ref string message)
        {
            Customer customer;
            try
            {
                using (var context = new CustomerContext())
                {
                    customer = context.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                    if (customer == null)
                    {
                        message = "Customer not found with ID provided";
                        return null;
                    }
                    context.Entry(customer).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                message = $"An error occured. {ex.Message} : {ex.InnerException}";
                return null;
            }

            return customer;
        }



        public bool SaveOrder()
        {
            Console.WriteLine("Enter Order Display Number: ");
            var ordNum = Console.ReadLine();

            Console.WriteLine("Enter Customer Id: ");
            var cusidstring = Console.ReadLine();
            int.TryParse(cusidstring, out int custid);

            Console.WriteLine("Enter Item Count: ");
            var itemCount = Console.ReadLine();
           // int.TryParse(ordCountstring, out int itemCount);

            Console.WriteLine("is Customer Fulfiled: ");
            var isfulstring = Console.ReadLine();
           // bool.TryParse(ordCountstring, out bool isFulfiled);

            DateTime sysDate = DateTime.Now;
            var order = new Order()
            {



                OrderDisplayNumber = ordNum,
                CustomerId = custid,
                PurchaseDate = DateTime.Now,
                IsFufilled = true,
                ItemCount = itemCount


            };


            try
            {
                using (var context = new CustomerContext())
                {
                    context.Orders.Add(order);

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new CustomerContext())
                {
                    //LINQ METHOD
                    orders = context.Orders.ToList();

                    ////LINQ QUERY
                    //var query = from customer in context.Customers
                    //            select customer;
                    //customers = query.ToList();

                    ////NATIVE SQL
                    //customers = context.Customers.SqlQuery("select * from [TSQL2012].[Sales].[Customers]").ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return orders;
        }


        public bool UpdateOrder(int orderId)
        {
            try
            {
                using (var context = new CustomerContext())
                {

                    Console.WriteLine("Enter Item Count: ");
                    var itemCount = Console.ReadLine();
                    //int.TryParse(ordCountstring, out int itemCount);


                    var order = context.Orders.FirstOrDefault(x => x.OrderId == orderId);

                    order.ItemCount = itemCount;
                    //order.PurchaseDate = DateTime.Now;

                    context.Entry(order).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public Order DeleteOrder(int orderId, ref string message)
        {
            Order order;
            try
            {
                using (var context = new CustomerContext())
                {
                    order = context.Orders.FirstOrDefault(x => x.OrderId == orderId);

                    if (order == null)
                    {
                        message = "Order not found with display number provided";
                        return null;
                    }
                    context.Entry(order).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                message = $"An error occured. {ex.Message} : {ex.InnerException}";
                return null;
            }

            return order;
        }


        public Order GetOrderById(int orderId)
        {
            var order = new Order();
            try
            {
                //using (var context = new MarketDBEntities())
                using (var context = new CustomerContext())
                {
                    //LINQ METHOD
                    order = context.Orders.FirstOrDefault(x => x.OrderId == orderId);

                    ////LINQ QUERY
                    //var query = from cust in context.Customers
                    //            where cust.CustomerID == customerId
                    //            select cust;
                    //customer = query.FirstOrDefault();

                    ////NATIVE SQL
                    // customer = context.Customers.SqlQuery($"select * from [TSQL2012].[Sales].[Customers] where custid = {customerId}").FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return order;
        }

    }
}
