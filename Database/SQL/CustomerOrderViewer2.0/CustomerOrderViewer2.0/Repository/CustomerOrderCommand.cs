using CustomerOrderViewer2._0.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CustomerOrderViewer2._0.Repository
{
    class CustomerOrderCommand
    {
        private string _connectionString;

        public CustomerOrderCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<CustomerOrderDetailModel> GetList()
        {
            var customerOrders = new List<CustomerOrderDetailModel>();

            var getCustomerOrderListSQLStoredProcedureCommand = "CustomerOrderDetail_GetList";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                customerOrders = connection.Query<CustomerOrderDetailModel>(getCustomerOrderListSQLStoredProcedureCommand).ToList();
            }

            return customerOrders;
        }

        public void Delete(int customerOrderId, string userId)
        {
            var deleteStoredProcedureStatement = "CustomerOrderDetail_Delete";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(deleteStoredProcedureStatement, new {  @CustomerOrderId = customerOrderId, @UserId = userId },
                                                                          commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Upsert(int customerOrderId, int customerId, int itemId, string userId)
        {
            var upsertStoredProcedureStatement = "CustomerOrderDetail_Upsert";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CustomerOrderId", typeof(int));
            dataTable.Columns.Add("CustomerId", typeof(int));
            dataTable.Columns.Add("ItemId", typeof(int));
            dataTable.Rows.Add(customerOrderId, customerId, itemId);

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(upsertStoredProcedureStatement, new { @CustomerOrderType = dataTable.AsTableValuedParameter("CustomerOrderType"), @UserId = userId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
