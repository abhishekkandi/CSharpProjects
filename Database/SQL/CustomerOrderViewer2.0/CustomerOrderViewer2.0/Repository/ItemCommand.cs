using CustomerOrderViewer2._0.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CustomerOrderViewer2._0.Repository
{
    class ItemCommand
    {
        private string _connectionString;

        public ItemCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<ItemModel> GetList()
        {
            var items = new List<ItemModel>();

            var getItemListSQLStoredProcedureCommand = "Item_GetList";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                items = connection.Query<ItemModel>(getItemListSQLStoredProcedureCommand).ToList();
            }

            return items;
        }
    }
}
