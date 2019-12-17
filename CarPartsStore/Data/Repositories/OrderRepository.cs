using System;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Repositories
{
    public class OrderRepository :IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShopCart _shopCart;

        public OrderRepository(ShopCart shopCart, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);
            var shopCartItems = _shopCart.ShopCartItems;
            foreach (var item in shopCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    CarpartId = item.Carpart.CarpartId,
                    OrderId = order.OrderId,
                    Price = item.Carpart.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}