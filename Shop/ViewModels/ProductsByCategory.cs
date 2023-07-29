using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
namespace Shop.ViewModels
{
    public class ProductsByCategory
    {
        public IEnumerable<Product> products { set; get; } 
        public string currCategory { get; set; }
    }
}
