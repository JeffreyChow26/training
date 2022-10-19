using CheckoutApp_CL.BL;
using CheckoutApp_CL.DAL;
using CheckoutApp_CL.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutApp_Test.BL
{
    public partial class InventoryBLTests
    {
        [Test]
        public void AddToBasket_CountIncrements_Moq() => AddToBasket_CountIncrements(GetMoqDAL());
        [Test]
        public void AddToBasket_CountIncrements_Stub() => AddToBasket_CountIncrements(GetStubDAL());
        [Test]
        public void AddToBasket_ItemNoExists_Throws_Moq() => AddToBasket_ItemNoExists_Throws(GetMoqDAL());
        [Test]
        public void AddToBasket_ItemNoExists_Throws_Stub() => AddToBasket_ItemNoExists_Throws(GetStubDAL());

        [Test]
        public void CheckoutItems_SumCalculated_Moq() => CheckoutItems_SumCalculated(GetMoqDAL()); 
        [Test]
        public void CheckoutItems_SumCalculated_Stub() => CheckoutItems_SumCalculated(GetStubDAL()); 

        [Test]
        public void CheckoutItems_RequiresOrder_Set_Moq() => CheckoutItems_RequiresOrder_Set(GetMoqDAL()); 
        [Test]
        public void CheckoutItems_RequiresOrder_Set_Stub() => CheckoutItems_RequiresOrder_Set(GetStubDAL()); 

        [Test]
        public void CheckoutItems_InventoryCountDecreases_Moq() => CheckoutItems_InventoryCountDecreases(GetMoqDAL(CheckoutItems_RequiresOrder_Set_Callback)); 
        [Test]
        public void CheckoutItems_InventoryCountDecreases_Stub() => CheckoutItems_InventoryCountDecreases(GetStubDAL(CheckoutItems_RequiresOrder_Set_Callback)); 

        private void AddToBasket_CountIncrements(IInventoryDAL dal)
        {
            var bl = new InventoryBL(dal);

            Assert.AreEqual(0, bl.Basket.Count);

            bl.AddToBasket(1);

            Assert.AreEqual(1, bl.Basket.Count);
            Assert.AreEqual(1, bl.Basket[1]);

            bl.AddToBasket(1);

            Assert.AreEqual(1, bl.Basket.Count);
            Assert.AreEqual(2, bl.Basket[1]);
        }

        private void AddToBasket_ItemNoExists_Throws(IInventoryDAL dal)
        {
            var bl = new InventoryBL(dal);
            
            Assert.Throws<Exception>(() =>
            {
                bl.AddToBasket(99999);
            });
        }

        private void CheckoutItems_SumCalculated(IInventoryDAL dal)
        {
            var bl = new InventoryBL(dal);

            bl.AddToBasket(1);
            bl.AddToBasket(1);

            int sum = bl.CheckoutItems();

            Assert.AreEqual(100, sum);
        }

        private void CheckoutItems_RequiresOrder_Set_Callback(ItemOrder item)
        {
            Assert.True(item.RequiresPreorder);
        }

        private void CheckoutItems_RequiresOrder_Set(IInventoryDAL dal)
        {
            var bl = new InventoryBL(dal);

            Assert.AreEqual(1, bl.Items.First(x => x.InventoryItemId == 1).CountInStock);

            bl.AddToBasket(1);
            bl.AddToBasket(1);

            int sum = bl.CheckoutItems();

            Assert.AreEqual(0, bl.Items.First(x => x.InventoryItemId == 1).CountInStock);
        }

        private void CheckoutItems_InventoryCountDecreases(IInventoryDAL dal)
        {
            var bl = new InventoryBL(dal);

            Assert.AreEqual(1, bl.Items.First(x => x.InventoryItemId == 1).CountInStock);

            bl.AddToBasket(1);
            bl.AddToBasket(1);
            bl.CheckoutItems();

            Assert.AreEqual(0, bl.Items.First(x => x.InventoryItemId == 1).CountInStock);
        }

        private static IInventoryDAL GetMoqDAL(Action<ItemOrder> action = null)
        {
            var mockDal = new MockInventoryDAL(null);
            var mock = new Mock<IInventoryDAL>();

            mock.Setup(m => m.GetInventoryItems()).Returns(mockDal.GetInventoryItems());

            if (action != null)
            {
                mock.Setup(m => m.SaveNewOrder(It.IsAny<ItemOrder>())).Callback(action);
            }

            return mock.Object;
        }

        private static IInventoryDAL GetStubDAL(Action<ItemOrder> action = null)
        {
            return new MockInventoryDAL(action);
        }

        public class MockInventoryDAL : IInventoryDAL
        {
            private readonly Action<ItemOrder> _action;

            public MockInventoryDAL(Action<ItemOrder> action)
            {
                _action = action;
            }

            public List<InventoryItem> GetInventoryItems()
            {
                return new List<InventoryItem>()
                {
                    new InventoryItem()
                    {
                        InventoryItemId = 1,
                        Description = "Mock item",
                        Price = 50,
                        CountInStock = 1
                    }
                };
            }

            public void SaveNewOrder(ItemOrder newOrder)
            {
                _action?.Invoke(newOrder);
            }

            public void UpdateInventoryCount(List<InventoryItem> updatedList)
            {

            }
        }
    }
}
