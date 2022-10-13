using System;
using System.Collections.Generic;

namespace Generics_Delegates_Exercise
{
    public class Checkout<TVehicle> where TVehicle : IVehicle, IEquatable<TVehicle>
    {
        private readonly Dictionary<TVehicle, int> _orders;

        public Checkout()
        {
            _orders = new Dictionary<TVehicle, int>();
        }

        public void AddToCheckout(TVehicle item)
        {
            foreach (var keyValue in _orders)
            {
                if (keyValue.Key.Equals(item))
                {
                    _orders[keyValue.Key] = keyValue.Value + 1;
                    return;
                }
            }

            _orders.Add(item, 1);
        }

        public void PrintOrders()
        {
            Console.WriteLine($"{Environment.NewLine}Order consists of the following:");

            foreach (var kv in _orders)
            {
                var itemInstance = kv.Key;
                var info = $"Item Brand: {itemInstance.Brand}{Environment.NewLine}";
                info += $"Item Year: {itemInstance.Year:d}{Environment.NewLine}";
                info += $"Item Color: {itemInstance.Color}";

                Console.WriteLine($"{info}");
                Console.WriteLine($"Quantity {kv.Value} {Environment.NewLine}");
            }
        }
    }
}
