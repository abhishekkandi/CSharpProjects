using CustomerOrderViewer2._0.Models;
using CustomerOrderViewer2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderViewer2._0
{
    /*
          Demonstrating - StoredProcedure, User-Defined Table Types
          Packages - Dapper, SqlClient
    */

    class Program
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=CustomerOrderViewer;Integrated Security=True";
        private static readonly ItemCommand _itemCommand = new ItemCommand(connectionString);
        private static readonly CustomerCommand _customerCommand = new CustomerCommand(connectionString);
        private static readonly CustomerOrderCommand _customerOrderCommand = new CustomerOrderCommand(connectionString);

        static void Main(string[] args)
        {
            try
            {
                var continueManaging = true;
                var userId = string.Empty;

                Console.WriteLine("What's your name?");
                userId = Console.ReadLine();

                do
                {
                    Console.WriteLine("1 - Show All | 2 - Upsert Customer Order | 3 - Delete Customer Order | 4 - Exit");

                    int option = Convert.ToInt32(Console.ReadLine());

                    if (option == 1)
                    {
                        ShowAll();
                    }
                    else if (option == 2)
                    {
                        UpsertCustomerOrder(userId);
                    }
                    else if (option == 3)
                    {
                        DeleteCustomerOrder(userId);
                    }
                    else if (option == 4)
                    {
                        continueManaging = false;
                    }
                    else
                    {
                        Console.WriteLine("Option not found.");
                    }

                } while (continueManaging);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
        }

        private static void ShowAll()
        {
            Console.WriteLine($"{Environment.NewLine}All Customer Orders: {Environment.NewLine}");
            DisplayCustomerOrders();

            Console.WriteLine($"{Environment.NewLine}All Customers: {Environment.NewLine}");
            DisplayCustomers();

            Console.WriteLine($"{Environment.NewLine}All Items: {Environment.NewLine}");
            DisplayItems();

            Console.WriteLine();
        }

        private static void DisplayItems()
        {
            IList<ItemModel> items = _itemCommand.GetList();

            if (items.Any())
            {
                foreach(var item in items)
                {
                    Console.WriteLine($"{item.ItemId}: Descripion: {item.Description}, Price {item.Price}");
                }
                
            }
        }

        private static void DisplayCustomers()
        {
            IList<CustomerModel> customers = _customerCommand.GetList();

            if (customers.Any())
            {
                foreach (CustomerModel customer in customers)
                {
                    Console.WriteLine($"{customer.CustomerId}: First Name: {customer.FirstName}, Middle Name: {customer.MiddleName ?? "N/A"}, Last Name: {customer.LastName}, Age: {customer.Age}");
                }
            }
        }

        private static void DisplayCustomerOrders()
        {
            IList<CustomerOrderDetailModel> customerOrderDetails = _customerOrderCommand.GetList();

            if (customerOrderDetails.Any())
            {
                foreach (CustomerOrderDetailModel customerOrderDetail in customerOrderDetails)
                {
                    Console.WriteLine(String.Format("{0}: Fullname: {1} {2} (Id: {3}) - purchased {4} for {5} (Id: {6})",
                        customerOrderDetail.CustomerOrderId,
                        customerOrderDetail.FirstName,
                        customerOrderDetail.LastName,
                        customerOrderDetail.CustomerId,
                        customerOrderDetail.Description,
                        customerOrderDetail.Price,
                        customerOrderDetail.ItemId));
                }
            }
        }

        private static void DeleteCustomerOrder(string userId)
        {
            Console.WriteLine("Enter CustomerOrderId:");
            int customerOrderId = Convert.ToInt32(Console.ReadLine());

            _customerOrderCommand.Delete(customerOrderId, userId);
        }

        private static void UpsertCustomerOrder(string userId)
        {
            Console.WriteLine("Note: For updating insert existing CustomerOrderId, for new entries enter -1.");

            Console.WriteLine("Enter CustomerOrderId:");
            int newCustomerOrderId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter CustomerId:");
            int newCustomerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter ItemId:");
            int newItemId = Convert.ToInt32(Console.ReadLine());

            _customerOrderCommand.Upsert(newCustomerOrderId, newCustomerId, newItemId, userId);
        }

        
    }
}



