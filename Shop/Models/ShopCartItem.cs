using Shop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShopCartItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Price { get; set; }
    public ShopCart ShopCart { get; set; }
    public int ShopCartId { get; set; }

    public int Count { get; set; } = 1; // New field with default value 1
}
