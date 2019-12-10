using System.Collections.Generic;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get; }
        Car GetCarById(int carId);
        Car GetCarByVin(string carVin);
    }
}