using System.Collections.Generic;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Wheel", Description = "All wheel parts"},
                    new Category {CategoryName = "Lights", Description = "All light parts"}
                };
            }
        }
    }
}