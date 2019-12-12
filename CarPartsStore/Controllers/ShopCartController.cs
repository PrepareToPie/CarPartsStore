using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;
using CarPartsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICarpartRepository _carpartRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(ICarpartRepository carpartRep, ShopCart shopCart)
        {
            _carpartRep = carpartRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel { shopCart = _shopCart };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carpartRep.Carparts.FirstOrDefault(i => i.CarpartId == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
