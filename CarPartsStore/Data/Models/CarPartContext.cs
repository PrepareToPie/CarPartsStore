using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Data.Models
{
    public class CarPartContext : DbContext
    {
        public DbSet<CarPart> CarParts { get; set; }
        public CarPartContext(DbContextOptions<CarPartContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
