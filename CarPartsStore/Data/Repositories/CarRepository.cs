using System.Collections.Generic;
using System.Linq;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;
        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Car> Cars => _appDbContext.Cars;

        public Car GetCarById(int carId) =>
            _appDbContext.Cars.FirstOrDefault(p => p.CarId == carId);

        public Car GetCarByVin(string carVin) =>
            _appDbContext.Cars.FirstOrDefault(p => p.Vin == carVin);

    }
}