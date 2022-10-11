using System;

namespace Generics_Delegates_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CAR_SELECTION = 1;
            const int BIKE_SELECTION = 2;

            bool isAdmin = false;

            while (true)
            {
                Console.WriteLine("Selection:");
                Console.WriteLine("1. View Cars");
                Console.WriteLine("2. View MotorBike");

                switch (int.Parse(Console.ReadLine())) //Assume no error handling is required
                {
                    case CAR_SELECTION:
                        var carManagement = new CarManagement();
                        carManagement.Execute();
                        break;

                    case BIKE_SELECTION:
                        var bikeManagement = new BikeManagement();
                        bikeManagement.Execute();
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
