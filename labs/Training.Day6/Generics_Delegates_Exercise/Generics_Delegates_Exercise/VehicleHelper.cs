using System;
using System.Collections.Generic;

namespace Generics_Delegates_Exercise
{
    internal static class VehicleHelper
    {
        public static void PrintInventory<TVehicle>(
            Dictionary<int, TVehicle> allItemsInInventory,
            Checkout<TVehicle> checkOutInstance,
            Func<KeyValuePair<int, TVehicle>, string> formatFunc = null) where TVehicle : IVehicle, IEquatable<TVehicle>
        {
            int quitValue = -1;

            if (formatFunc == null)
            {
                formatFunc = FormatVehicleInfo;
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"This is the inventory: ");

                foreach (var itemKV in allItemsInInventory)
                {
                    string info = formatFunc(itemKV);

                    Console.WriteLine($"{info}"); Console.WriteLine();
                }

                Console.WriteLine("Please select Id or enter -1 to go back to previous menu");

                var inputId = int.Parse(Console.ReadLine()); //Assume that selection will not require error handling 

                if (inputId == quitValue) break;

                checkOutInstance.AddToCheckout(allItemsInInventory[inputId]);
                Console.WriteLine("Item has been added to checkout!");
            }
        }

        private static string FormatVehicleInfo<TVehicle>(KeyValuePair<int, TVehicle> kv) where TVehicle : IVehicle, IEquatable<TVehicle>
        {
            Console.WriteLine($"Inventory Id: {kv.Key}");

            var itemInstance = kv.Value;
            var info = $"Item Brand: {itemInstance.Brand}{Environment.NewLine}";
            info += $"Item Year: {itemInstance.Year:d}{Environment.NewLine}";
            info += $"Item Color: {itemInstance.Color}";

            return info;
        }
    }
}
