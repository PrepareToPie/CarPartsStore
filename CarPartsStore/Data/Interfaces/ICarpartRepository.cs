using System.Collections.Generic;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Interfaces
{
    public interface ICarpartRepository
    {
        IEnumerable<Carpart> Carparts { get; }
        Carpart GetCarpartById(int carpartId);
    }
}