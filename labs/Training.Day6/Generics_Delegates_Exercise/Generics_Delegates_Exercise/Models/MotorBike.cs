using System;

namespace Generics_Delegates_Exercise
{
    public class MotorBike : IVehicle, IEquatable<MotorBike>
    {
        public Brand Brand { get; set; }
        public DateTime Year { get; set; }
        public Color Color { get; set; }
        public int CountInStock { get; set; }

        public bool Equals(MotorBike other)
        {
            return Brand == other.Brand && Year == other.Year && Color == other.Color;
        }
    }
}
