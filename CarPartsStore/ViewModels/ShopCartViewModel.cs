using CarPartsStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart ShopCart { get; set; }
        public decimal ShopCartTotal { get; set; }
    };
}
