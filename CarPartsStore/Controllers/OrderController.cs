using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Controllers
{
    [Authorize(Roles = "user")]

    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShopCart _shopCart;

        public OrderController(IOrderRepository orderRepository, ShopCart shopCart)
        {
            _orderRepository = orderRepository;
            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.ShopCartItems = items;

            //if (_shopCart.ShopCartItems.Count == 0)
            //{
            //    ModelState.AddModelError("", "Корзина пуста");
            //}
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shopCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Спасибо за заказ!";
            return View();
        }
    }
}