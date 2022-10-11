using System;
using System.Collections.Generic;

namespace Generics_Delegates_Exercise
{
    //Just assume this is coming from a data source
    internal static class InventoryRepo
    {
        static int id = 0;

        public static Dictionary<int, Car> InventoryCars = new Dictionary<int, Car>()
            {
                { ++id, new Car()
                    {
                        Brand = Brand.Toyota,
                        Year = DateTime.Today,
                        Color =  Color.Silver
                    }
                },
                { ++id, new Car()
                    {
                        Brand = Brand.Tesla,
                        Year = DateTime.Today.AddDays(-19),
                        Color =  Color.White
                    }
                },
            };

        public static Dictionary<int, MotorBike> InventoryBikes = new Dictionary<int, MotorBike>()
            {
                { ++id, new MotorBike()
                    {
                        Brand = Brand.Honda,
                        Year = DateTime.Today,
                        Color =  Color.Silver,
                        CountInStock = 10
                    }
                },
                { ++id, new MotorBike()
                    {
                        Brand = Brand.BMW,
                        Year = DateTime.Today.AddDays(-19),
                        Color =  Color.White,
                        CountInStock = 12
                    }
                },
            };

    }
}
