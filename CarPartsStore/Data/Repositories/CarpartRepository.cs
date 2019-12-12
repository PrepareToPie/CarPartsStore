using System.Collections.Generic;
using System.Linq;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPartsStore.Data.Repositories
{
    public class CarpartRepository : ICarpartRepository
    {
        private AppDbContext _appDbContext;
        public CarpartRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Carpart> Carparts => _appDbContext.Carparts.Include(c => c.Category);

        public Carpart GetCarpartById(int carpartId) =>
            _appDbContext.Carparts.FirstOrDefault(p => p.CarpartId == carpartId);
    }
}