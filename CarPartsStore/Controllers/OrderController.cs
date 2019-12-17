using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Controllers
{
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
    }
}