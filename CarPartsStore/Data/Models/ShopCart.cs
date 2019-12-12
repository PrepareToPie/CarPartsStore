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
        public ShopCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Carpart carpart)
        {
            _appDbContext.ShopCartItems.Add(new ShopCartItem 
            {
                ShopCartId = ShopCartId,
                Carpart = carpart,
                Price = carpart.Price
            });

            _appDbContext.SaveChanges();
        }

        // public int RemoveFromCart(Carpart carpart)
        // {
        //     var shoppingCartItem = _appDbContext.ShopCartItems.SingleOrDefault(s =>
        //         s.Carpart.CarpartId == carpart.CarpartId && s.ShopCartId == ShopCartId);
        //     var localAmount = 0;
        //     if (shoppingCartItem != null)
        //     {
        //         if(shoppingCartItem.)
        //     }
        // }
        public void ClearCart()
        {
            var cartItems = _appDbContext.ShopCartItems.Where(cart => cart.ShopCartId == ShopCartId);
            _appDbContext.ShopCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }
        public List<ShopCartItem> GetShopItems()
        {
            
            return _appDbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Carpart).ToList();
        }

        // public GetShoppingCartTotal()
        // {
        //     var total = _appDbContext.ShopCartItems.Where(c=>c.ShopCartId == ShopCartId).Select(c=>c. * c.)
        // }
            
    }
}
