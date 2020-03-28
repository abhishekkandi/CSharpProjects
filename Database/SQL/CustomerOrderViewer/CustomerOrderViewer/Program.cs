using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand("Data Source=localhost;Initial Catalog=CustomerOrderViewer;Integrated Security=True");

                IList<CustomerOrderDetailModel> customerOrders = customerOrderDetailCommand.GetList();

                if (customerOrders.Any())
                {
                    foreach(var customerOrder in customerOrders)
                    {
                        Console.WriteLine($"{customerOrder.CustomerOrderId}: FullName: {customerOrder.FirstName} {customerOrder.LastName} (CustomerId: {customerOrder.CustomerId}) - purchased {customerOrder.Description} for {customerOrder.Price} (ItemId: {customerOrder.ItemId})");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
            
        }
    }
}
