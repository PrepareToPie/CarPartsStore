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
        private AppDbContext _appDbContext;
        public ShopCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }
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
                carpart = carpart,
                price = carpart.Price
            });

            _appDbContext.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return _appDbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.carpart).ToList();
        }
    }
}
