using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System.Text.Json;

namespace Shop.Controllers
{
    public class Likes : Controller
    {
       private readonly ApplicationContext db;

        public Likes(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int shopcartId)
        {
            var likedProducts = db.LikedProducts
        .Where(lp => lp.ShopCartId == shopcartId)
        .Include(lp => lp.Product) 
        .ToList();


            ViewBag.products = likedProducts;

            return View();
        }

        public bool IsProductLiked(int shopcartid, string productName)
        {
            var product = db.LikedProducts.FirstOrDefault(x => x.Product.Name == productName);
            if (product == null) { return false; }
            return true;
        }


        [HttpPost]
        public IActionResult AddToLikedList(string productName)
        {
            var shopCartJson = HttpContext.Session.GetString("ShopCart");
            var shopCart = JsonSerializer.Deserialize<ShopCart>(shopCartJson);
            int shopCartId = shopCart.ShopCartId;

            var obj = db.Products.FirstOrDefault(x => x.Name == productName);
            LikedProduct item = new LikedProduct { ShopCartId = shopCartId, Product = obj };

            db.LikedProducts.Add(item);
            db.SaveChanges();


            

            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteFromLikedList(string productName)
        {
            
            var shopCartJson = HttpContext.Session.GetString("ShopCart");
            var shopCart = JsonSerializer.Deserialize<ShopCart>(shopCartJson);

            var obj = db.LikedProducts.FirstOrDefault(x => x.Product.Name == productName && x.ShopCartId == shopCart.ShopCartId);

            db.LikedProducts.Remove(obj);
            db.SaveChanges();

            return Ok(); 
        }


    }
}
