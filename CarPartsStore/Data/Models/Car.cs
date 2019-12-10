using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace CarPartsStore.Data.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Vin { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
    }
}