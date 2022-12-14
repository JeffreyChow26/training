using CheckoutApp_CL.DAL;
using CheckoutApp_CL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutApp_CL.BL
{
    public class InventoryBL
    {
        private readonly IInventoryDAL _dal;

        public Dictionary<int, int> Basket { get;  } // Stores Id of item + Count
        public List<InventoryItem> Items { get; set; }

        public InventoryBL(IInventoryDAL dal)
        {
            _dal = dal;

            Basket = new Dictionary<int, int>();
            Items = _dal.GetInventoryItems();
        }

        public void AddToBasket(int id)
        {
            if (!Items.Any(z => z.InventoryItemId == id))
            {
                throw new Exception("Invalid Id");
            }

            if (!Basket.ContainsKey(id))
            {
                Basket.Add(id, 0);
            }

            Basket[id]++;
        }

        public int CheckoutItems()
        {
            var newOrder = new ItemOrder();

            foreach (var itemInBasket in Basket)
            {
                var item = Items.First(z => z.InventoryItemId == itemInBasket.Key);

                newOrder.TotalPrice += item.Price * itemInBasket.Value;

                if (itemInBasket.Value > item.CountInStock) // More has been requested than we have in stock we need to reorder
                    newOrder.RequiresPreorder = true;
            }

            UpdateInventoryCount();
            
            _dal.SaveNewOrder(newOrder);

            return newOrder.TotalPrice;
        }

        private void UpdateInventoryCount()
        {
            var updatedList = new List<InventoryItem>();

            foreach (var item in Items)
            {
                if (!Basket.ContainsKey(item.InventoryItemId))
                    continue;

                item.CountInStock -= Basket[item.InventoryItemId];

                if (item.CountInStock < 0)
                    item.CountInStock = 0;

                updatedList.Add(item);
            }

            _dal.UpdateInventoryCount(updatedList);
        }
    }
}
