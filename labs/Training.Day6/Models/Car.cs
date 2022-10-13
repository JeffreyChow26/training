using System;

namespace Generics_Delegates_Exercise
{
    public class Car : IVehicle, IEquatable<Car>
    {
        public Brand Brand { get; set; }
        public DateTime Year { get; set; }  
        public Color Color { get; set; }

        public bool Equals(Car other)
        {
            return Brand ==  other.Brand && Year == other.Year && Color == other.Color; 
        }
    }
}
