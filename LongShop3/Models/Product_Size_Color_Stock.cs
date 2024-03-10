namespace LongShop3.Models
{
    public class Product_Size_Color_Stock
    {
        public ProductDetail pd { get; set; } = new ProductDetail();
        public Size size { get; set; } = new Size();
        public Color color { get; set; } = new Color();
        public SizeColorStock scs { get; set; } = new SizeColorStock();
        public List<Image> images { get; set; } = new List<Image>();
        public Cart cart { get; set; } = new Cart();
    }
}
