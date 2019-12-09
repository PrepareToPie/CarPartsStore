using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Data.Models
{
    public sealed class CarpartContext : DbContext
    {
        public DbSet<Carpart> CarParts { get; set; }
        public CarpartContext(DbContextOptions<CarpartContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
