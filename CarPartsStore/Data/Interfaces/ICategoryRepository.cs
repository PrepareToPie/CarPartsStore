using System.Collections.Generic;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}