namespace Shop.Models
{
    public class LikedProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public ShopCart ShopCart { get; set; }
        public int ShopCartId { get; set; }
    }
}

