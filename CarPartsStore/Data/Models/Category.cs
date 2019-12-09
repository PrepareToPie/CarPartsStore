using System.Collections.Generic;

namespace CarPartsStore.Data.Models
{
    // Моделька для категорий
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //public List<CarPart> CarParts { get; set; }
    }
}