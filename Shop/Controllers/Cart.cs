using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationContext db;

        public CartController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult AddToCart(string productName)
        {
            var shopCartJson = HttpContext.Session.GetString("ShopCart");
            var shopCart = JsonSerializer.Deserialize<ShopCart>(shopCartJson);
            int shopCartId = shopCart.ShopCartId;

            var obj = db.Products.FirstOrDefault(x => x.Name == productName);
            ShopCartItem item = new ShopCartItem { ShopCartId = shopCartId, Product = obj, Price = obj.Price };

            db.ShopCartItems.Add(item);
            db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteFromCart(string productName)
        {

            var shopCartJson = HttpContext.Session.GetString("ShopCart");
            var shopCart = JsonSerializer.Deserialize<ShopCart>(shopCartJson);

            var obj = db.ShopCartItems.FirstOrDefault(x => x.Product.Name == productName);

            db.ShopCartItems.Remove(obj);
            db.SaveChanges();

            return Ok();
        }


        [HttpPost]
        public IActionResult ChangeShopCartItemCount(int shopCartId, string productName, int count)
        {
            var shopCartItem = db.ShopCartItems
                .Include(x => x.Product)
                .FirstOrDefault(x => x.ShopCartId == shopCartId && x.Product.Name == productName);


            if (shopCartItem != null)
            {
                shopCartItem.Count = count;
                db.SaveChanges();
            }

            return Ok();

        }
    }
}

