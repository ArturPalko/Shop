using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class Order : Controller
    {
        private readonly ApplicationContext db;
        public Order(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int shopcartid)
        {

            return View();
        }
    }
}
