using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;
using CarPartsStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Controllers
{
    [Authorize(Roles = "user")]
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
            var items = _shopCart.GetShopCartItems();
            _shopCart.ShopCartItems = items;
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart,
                ShopCartTotal = _shopCart.GetShopCartTotal()
            };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int carpartId)
        {
            var selectedCarPart = _carpartRep
                .Carparts
                .FirstOrDefault(i => i.CarpartId == carpartId);
            if (selectedCarPart != null)
            {
                _shopCart.AddToCart(selectedCarPart, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int carpartId)
        {
            var selectedCarpart = _carpartRep.Carparts.FirstOrDefault(i => i.CarpartId == carpartId);
            if (selectedCarpart != null)
            {
                _shopCart.RemoveFromCart(selectedCarpart);
            }

            return RedirectToAction("Index");
        }
    }
}
