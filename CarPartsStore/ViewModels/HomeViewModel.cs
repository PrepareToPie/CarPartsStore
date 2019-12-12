using System.Collections.Generic;
using System.Linq;
using CarPartsStore.Data.Models;

namespace CarPartsStore.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Carpart> IsInStock
        {
            get;
            set;
        }
    }
}