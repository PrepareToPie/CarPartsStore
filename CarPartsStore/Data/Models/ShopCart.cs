using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContext _appDbContext;

        private ShopCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            ShopCartItems = new List<ShopCartItem>();
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }

        #region ShopCart methods

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) {ShopCartId = shopCartId};
        }

        public void AddToCart(Carpart carpart, int amount)
        {
            var shopCartItem = _appDbContext.ShopCartItems.SingleOrDefault(s =>
                s.Carpart.CarpartId == carpart.CarpartId && s.ShopCartId == ShopCartId);
            if (shopCartItem == null)
            {
                shopCartItem = new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    Carpart = carpart,
                    Amount = 1
                };
                _appDbContext.ShopCartItems.Add(shopCartItem);
            }
            else
            {
                shopCartItem.Amount++;
            }

            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Carpart carpart)
        {
            var shopCartItem = _appDbContext.ShopCartItems.SingleOrDefault(s =>
                s.Carpart.CarpartId == carpart.CarpartId && s.ShopCartId == ShopCartId);
            var localAmount = 0;
            if (shopCartItem != null)
            {
                if (shopCartItem.Amount > 1)
                {
                    shopCartItem.Amount--;
                    localAmount = shopCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShopCartItems.Remove(shopCartItem);
                }
            }

            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return ShopCartItems ??= _appDbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId)
                .Include(s => s.Carpart)
                .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShopCartItems
                .Where(cart => cart.ShopCartId == ShopCartId);
            _appDbContext.ShopCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public decimal GetShopCartTotal()
        {
            var total = _appDbContext
                .ShopCartItems
                .Where(c => c.ShopCartId == ShopCartId)
                .Select(c => c.Carpart.Price * c.Amount).Sum();
            return total;
        }

        #endregion
    }
}
