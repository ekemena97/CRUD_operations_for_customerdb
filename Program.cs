using ConsoleApp4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            getUserInput();


        }
        static void getUserInput()
        {

            Console.WriteLine("<<<<<<< Welcome to Customer - Order Application >>>>>>>");

            Console.WriteLine("Press the following:\n (1) Add Customer\n (2) Update Customer\n (3) Delete a Customer" +
                "\n (4) Retrieve All Customers\n (5) Add Order\n (6) Update Order\n (7) Delete Order\n (8) Retrieve All Orders\n (9) Retrieve Customer by ID\n (10) Retrieve Order by ID\n (00) Exit Console Application");

            var userInputstring = Console.ReadLine();
            int.TryParse(userInputstring, out int userInput);



            var customerOperations = new CustomerOperations();

            if (userInput == 1)
            {

                //ADD CUSTOMER----------------------------
                var saveCustomer = customerOperations.SaveCustomer();
                Console.WriteLine("Customer {0} {1}", saveCustomer ? "successfully added." : "failed.", "");
                Console.ReadKey();

                // System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                //Environment.Exit(0);
                Console.WriteLine("<------------------------------------------------------------------>");
                getUserInput();

                //  Console.WriteLine("Press the following:\n(1) Add Customer\n(2) Add Order\n(6) Retrieve All Customers" +
                //"\n(4) Retrieve Customer By ID\n(5) Retrieve Order\n(6)Update Customer\n(7)Delete Customer\n(8)Delete Order");
            }
            else if (userInput == 2)
            {

                //UPDATE CUSTOMER------------ -
                Console.WriteLine("Enter Customer ID to be Updated");
                var customerIdstring = Console.ReadLine();
                int.TryParse(customerIdstring, out int customerId);
                if (customerId == 0)
                {
                    Console.WriteLine("Invalid customer ID entered. ID must be integer.");
                    Console.ReadLine();
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                }

                var updateCustomer = customerOperations.UpdateCustomer(customerId);
                Console.WriteLine(
                    "Customer updated {0}", updateCustomer ? "successfully." : "failed.");

                Console.ReadKey();
                Console.WriteLine("<------------------------------------------------------------------>");
                getUserInput();
            }
            else if (userInput == 3)
            {
                // DELETE CUSTOMER----------------------

                Console.WriteLine("Enter Customer ID to be deleted");
                var customerIdstring = Console.ReadLine();
                int.TryParse(customerIdstring, out int customerId);
                if (customerId == 0)
                {
                    Console.WriteLine("Invalid customer ID entered. ID must be integer.");
                    Console.ReadLine();
                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();
                }
                else
                {
                    string message = "";
                    var deleteCustomer = customerOperations.DeleteCustomer(customerId, ref message);
                    Console.WriteLine("Customer {1} {0}", deleteCustomer == null ? $"failed - {message}" : "was successfully deleted!.", deleteCustomer != null ? deleteCustomer.CompanyName : "");
                    Console.ReadKey();
                    Console.WriteLine("<----------------------------------------------------------------------------->");

                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();

                }


            }
            else if (userInput == 4)
            {
                //GET ALL CUSTOMERS
                Console.WriteLine("<<<<<LIST OF ALL CUSTOMERS>>>>>");
                var getCustomers = customerOperations.GetAllCustomers();

                getCustomers.ForEach(x => Console.WriteLine(($"(CustomerID)- {x.CustomerID}, (CompanyName) - {x.CompanyName}, (Address) -  {x.Address}, (Age) - {x.Age} , (PhonerNumber) - {x.PhoneNumber}")));
                Console.ReadKey();

                Console.WriteLine("<------------------------------------------------------------------>");
                getUserInput();

                //Console.WriteLine("----------------------------------------------");
            }
            else if (userInput == 5)
            {

                //ADD ORDER----------------------------
                var saveOrder = customerOperations.SaveOrder();
                Console.WriteLine("Order{0} {1}", saveOrder ? "was successfully added." : "failed.", "");
                Console.ReadKey();

                Console.WriteLine("<------------------------------------------------------------------>");
                getUserInput();


                //Get by phone number ---------------------------------------

                //Console.WriteLine("Enter your preffered country");
                //var country = Console.ReadLine();
                //if (string.IsNullOrEmpty(country))
                //{
                //    Console.WriteLine("Hey. No country entered");
                //}
                //else
                //{
                //    var getCustomersByCountry = customerOperations.GetAllCustomersByCountry(country);
                //    if (getCustomersByCountry.Count == 0)
                //        Console.WriteLine("No Country for the input entered");
                //    else
                //        getCustomersByCountry.ForEach(x => Console.WriteLine($"{x.companyname} : {x.address}"));
                //}

                //Console.WriteLine("----------------------------------------------");
                //Console.ReadKey();

            }
            else if (userInput == 6)
            {
                //UPDATE ORDER------------ -
                Console.WriteLine("You can only update ItemCount");
                Console.WriteLine("<--------------------------------------------------->");
                Console.WriteLine("Enter Order Display Number to be Updated");
                var orderIdstring = Console.ReadLine();
                int.TryParse(orderIdstring, out int orderId);
                if (orderId == 0)
                {
                    Console.WriteLine("Invalid Order Display Number entered. Display Number must be a string e.g ord101 .");
                    Console.ReadLine();
                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();
                }

                var updateOrder = customerOperations.UpdateOrder(orderId);
                Console.WriteLine(
                    "Order updated {0}", updateOrder ? "successfully." : "failed.");

                Console.ReadKey();
                Console.WriteLine("<------------------------------------------------------------------>");
                getUserInput();

            }
            else if (userInput == 7)
            {

                Console.WriteLine("Enter Orderr Display Number you want to delete");
                var orderIdstring = Console.ReadLine();
                int.TryParse(orderIdstring, out int orderId);
                if (orderId == 0)
                {
                    Console.WriteLine("Invalid order display number entered. Order must be integer.");
                    Console.ReadKey();

                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();
                }
                else
                {
                    string message = "";
                    var deleteOrder = customerOperations.DeleteOrder(orderId, ref message);
                    Console.WriteLine("Order {1} {0}", deleteOrder == null ? $"failed - {message}" : "was successfully deleted!.", deleteOrder != null ? deleteOrder.OrderDisplayNumber : "");
                    Console.ReadKey();
                    // Console.WriteLine("<----------------------------------------------------------------------------->");
                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();

                }

            }



            else if (userInput == 8)
            {

                Console.WriteLine("<<<<<LIST OF ALL ORDERS>>>>>");
                var getOrders = customerOperations.GetAllOrders();

                getOrders.ForEach(x => Console.WriteLine(($"(OrderId)-{x.OrderId},(OrderDisplayNum)-{x.OrderDisplayNumber},(ItemCount)-{x.ItemCount},(PurchaseDate)-{x.PurchaseDate},(CustomerID)-{x.CustomerId}")));
                Console.ReadKey();

                Console.WriteLine("<------------------------------------------------------------------>");
                getUserInput();
            }



            else if (userInput == 9)
            {

                //// Get  CUSTOMER by ID------------------------------ -
                Console.WriteLine("ENTER CUSTOMER ID");
                var customerIdstring = Console.ReadLine();

                int.TryParse(customerIdstring, out int customerId);
                if (customerId == 0)
                {
                    Console.WriteLine("Invalid customer ID entered. ID must be integer.");
                    Console.ReadLine();
                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();
                }
                else
                {
                    var getCustomer = customerOperations.GetCustomerById(customerId);
                    if (getCustomer == null)
                        Console.WriteLine("No Customer with the ID entered");

                    else
                        Console.WriteLine($"(COMPANY-NAME) - {getCustomer.CompanyName}\n(ADDRESS) - {getCustomer.Address}\n(AGE) - {getCustomer.Age}\n(PHONE) - {getCustomer.PhoneNumber}");
                    Console.ReadLine();
                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();
                }


            }

            else if (userInput == 10)
            {

                //// Get  ORDER by ID------------------------------ -
                Console.WriteLine("ENTER ORDER ID");
                var orderIdstring = Console.ReadLine();

                int.TryParse(orderIdstring, out int orderId);
                if (orderId == 0)
                {
                    Console.WriteLine("Invalid order ID entered. ID must be integer.");
                    Console.ReadLine();
                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();
                }
                else
                {
                    var getOrder = customerOperations.GetOrderById(orderId);
                    if (getOrder == null)
                        Console.WriteLine("No Order with the ID entered");
                    else
                        Console.WriteLine($"OrderDisplayNum) - {getOrder.OrderDisplayNumber}\n(ItemCount) - {getOrder.ItemCount}\n(PurchaseDate) - {getOrder.PurchaseDate}\n(isFulfilled) - {getOrder.IsFufilled}\n(CustomerId) - {getOrder.CustomerId}");
                    Console.ReadLine();
                    Console.WriteLine("<------------------------------------------------------------------>");
                    getUserInput();
                }


            }

            else if (userInput == 00)
            {
                Environment.Exit(0);
            }


            else
            {
                Console.WriteLine("Invalid Entry");
                Console.ReadKey();
                Console.WriteLine("<------------------------------------------------------------------>");
                getUserInput();
            }
        }

    }
}
