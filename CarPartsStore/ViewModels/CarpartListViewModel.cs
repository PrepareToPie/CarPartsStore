using System.Collections.Generic;
using CarPartsStore.Data.Models;

namespace CarPartsStore.ViewModels
{
    public class CarpartListViewModel
    {
        public IEnumerable<Carpart> Carparts { get; set; }
        public string CurrentCategory { get; set; }
    }
}