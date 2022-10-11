using System;

namespace Generics_Delegates_Exercise
{
    public interface IVehicle
    {
        Brand Brand { get; set; }
        DateTime Year { get; set; }  
        Color Color { get; set; }
    }
}
