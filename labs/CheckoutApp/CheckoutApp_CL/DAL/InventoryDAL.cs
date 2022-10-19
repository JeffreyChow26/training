using CheckoutApp_CL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CheckoutApp_CL.DAL
{
    public class InventoryDAL : CommonDAL, IInventoryDAL
    {
        public List<InventoryItem> GetInventoryItems()
        {
            string sql = $"select {Helper.GetColumnNames(typeof(InventoryItem))} from InventoryItem";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<InventoryItem> result = new List<InventoryItem>();

            while (dataReader.Read())
            {
                result.Add(new InventoryItem()
                {
                    InventoryItemId = Convert.ToInt32(dataReader.GetValue(dataReader.GetOrdinal("InventoryItemId")).ToString()),
                    Description = dataReader.GetValue(dataReader.GetOrdinal("Description")).ToString(),
                    CountInStock = Convert.ToInt32(dataReader.GetValue(dataReader.GetOrdinal("CountInStock")).ToString()),
                    Price = Convert.ToInt32(dataReader.GetValue(dataReader.GetOrdinal("Price")).ToString()),
                });
            }

            dataReader.Close();
            command.Dispose();

            return result;
        }

        public void SaveNewOrder(ItemOrder newOrder)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = $@"
                Insert into ItemOrder
                Values({newOrder.TotalPrice}, {(newOrder.RequiresPreorder ? 1 : 0)})";

            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.Dispose();
        }

        public void UpdateInventoryCount(List<InventoryItem> updatedList)
        {
            var sql = string.Empty;

            foreach (var item in updatedList)
            {
                sql += $@"Update InventoryItem 
                          Set CountInStock =  {item.CountInStock}
                          Where InventoryItemId = {item.InventoryItemId}
                          ";
            }

            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteScalar();
            command.Dispose();
        }
    }
}
