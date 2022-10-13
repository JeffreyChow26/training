using System;
using System.Collections.Generic;

namespace Generics_Delegates_Exercise
{
    internal class CarManagement
    {
        public void Execute()
        {
            const int MENU_OPT_INVENTORY_CAR = 1;
            const int MENU_OPT_VIEW_CHECKOUT = 2;

            var allCarsInInventory = InventoryRepo.InventoryCars;
            var checkOutInstance = new Checkout<Car>();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"Please Choose: {Environment.NewLine}");

                Console.WriteLine("1. See Car inventory");
                Console.WriteLine($"2. See checkout basket");
                Console.WriteLine($"-1. Go back{Environment.NewLine}");

                var menuSelection = int.Parse(Console.ReadLine());

                if (menuSelection == MENU_OPT_INVENTORY_CAR)
                {
                    VehicleHelper.PrintInventory(allCarsInInventory, checkOutInstance);
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
    }
}
