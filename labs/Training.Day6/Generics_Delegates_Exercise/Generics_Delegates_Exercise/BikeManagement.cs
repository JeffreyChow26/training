using System;
using System.Collections.Generic;

namespace Generics_Delegates_Exercise
{
    internal class BikeManagement
    {
        public void Execute(bool isAdmin)
        {
            const int MENU_OPT_INVENTORY_BIKE = 1;
            const int MENU_OPT_VIEW_CHECKOUT = 2;

            var allBikesInInventory = InventoryRepo.InventoryBikes;
            var checkOutInstance = new Checkout<MotorBike>();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"Please Choose: {Environment.NewLine}");

                Console.WriteLine("1. See Bike inventory");
                Console.WriteLine($"2. See checkout basket");
                Console.WriteLine($"-1. Go back{Environment.NewLine}");

                var menuSelection = int.Parse(Console.ReadLine());

                if (menuSelection == MENU_OPT_INVENTORY_BIKE)
                {
                    if (isAdmin)
                    {
                        VehicleHelper.PrintInventory(allBikesInInventory, checkOutInstance,  FormatBikeInfo);
                    }
                    else
                    {
                        VehicleHelper.PrintInventory(allBikesInInventory, checkOutInstance);
                    }
                }
                else if (menuSelection == MENU_OPT_VIEW_CHECKOUT)
                {
                    checkOutInstance.PrintOrders();
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }
        }
        private static string FormatBikeInfo(KeyValuePair<int, MotorBike> kv)
        {
            Console.WriteLine($"Inventory Id: {kv.Key}");

            var itemInstance = kv.Value;
            var info = $"Item Brand: {itemInstance.Brand}{Environment.NewLine}";
            info += $"Item Year: {itemInstance.Year:d}{Environment.NewLine}";
            info += $"Item Color: {itemInstance.Color}";
            info += $"Item Count: {itemInstance.CountInStock}";

            return info;
        }
    }
}
