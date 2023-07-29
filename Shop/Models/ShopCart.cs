using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class ShopCart
    {
        [Key]
        public int ShopCartId { get; set; }

        [ForeignKey("ShopCartId")]
        public List<ShopCartItem> ShopCartItems { get; set; }
    }
}
