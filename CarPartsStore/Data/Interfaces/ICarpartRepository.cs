using System.Collections.Generic;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Interfaces
{
    public interface ICarpartRepository
    {
        IEnumerable<Carpart> Carparts { get; }
        IEnumerable<Carpart> IsInStock { get; }
        Carpart GetCarpartById(int carpartId);
    }
}