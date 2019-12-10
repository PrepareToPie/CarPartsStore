using System.Collections.Generic;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> Categories => _appDbContext.Categories;
    }
}