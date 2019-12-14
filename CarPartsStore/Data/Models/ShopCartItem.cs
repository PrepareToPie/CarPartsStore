using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Data.Models
{
    public class ShopCartItem
    {
        public int ShopCartItemId { get; set; }
        public Carpart Carpart { get; set; }
        public int Amount { get; set; }
        public string ShopCartId { get; set; }
        
    }
}
