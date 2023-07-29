using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;

        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }
      
        public async Task<IActionResult> Index()
        {

             List<Category> categories = db.Categories.ToList();
             List<Product> products=   db.Products.ToList();
             HttpContext.Session.Remove("ShopCart");

            if (!HttpContext.Session.TryGetValue("ShopCart", out byte[] shopCartBytes))
              {
                  var shopCart = HttpContext.Session.GetString("ShopCart");
                if (string.IsNullOrEmpty(shopCart))
                {
                    var newShopCart = new ShopCart();
                    newShopCart.ShopCartId = Math.Abs(Guid.NewGuid().GetHashCode());
                    db.ShopCarts.Add(newShopCart);
                    db.SaveChanges();
                    HttpContext.Session.SetString("ShopCart", JsonSerializer.Serialize(newShopCart));
                    ViewBag.shopcartid= newShopCart.ShopCartId;

                }     
            }
            
            ViewBag.Products = products;
            ViewBag.Categories = categories;

            return View();
        }
        public async Task<IActionResult> Cart(int shopcartid)
        {
            List<ShopCartItem> shopcartitems = db.ShopCartItems
                .Include(item => item.Product)
                .Where(item => item.ShopCartId == shopcartid)
                .ToList();

            ViewBag.Products = shopcartitems;

            // Получение значения ShopCartId из сессии
            if (HttpContext.Session.TryGetValue("ShopCart", out byte[] shopCartBytes))
            {
                var shopCart = JsonSerializer.Deserialize<ShopCart>(shopCartBytes);
                ViewBag.ShopCartId = shopCart.ShopCartId;
            }

            return View("Cart");
        }

        public async Task<IActionResult> Category(string name)
        {
            List<Category> categories = db.Categories.ToList();
            List<Product> products = db.Products.Where(p => p.Category.Name == name).ToList();

            
            ViewBag.Products = products;
            ViewBag.Categories = categories;


            return View("Index");
        }


    }
}
