using CarPartsStore.Data.Models;
using CarPartsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CarPartsStore.Components
{
    public class ShopCartSummary : ViewComponent
    {
        private readonly ShopCart _shopCart;

        public ShopCartSummary(ShopCart shopCart)
        {
            _shopCart = shopCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.ShopCartItems = items;
            var shopCartViewModel = new ShopCartViewModel
            {
                ShopCart = _shopCart,
                ShopCartTotal = _shopCart.GetShopCartTotal()
            };
            return View(shopCartViewModel);
        }
    }
}