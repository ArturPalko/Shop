using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product
    {
        
        public int Id { set; get; }
        public string  Name { set; get; }
        public int Price { set; get; }
        public string Img { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }

    }

}

