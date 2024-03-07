namespace LongShop3.Models
{
    public class ProductWithImageColor
    {
        public ProductDetail pd { get; set; } = new ProductDetail();
        public Color color { get; set; } = new Color();
        public List<Image> images { get; set; } = new List<Image>();
    }
}
