namespace LongShop3.Models
{
    public class Product_Brand_Cate
    {
        public ProductDetail pd { get; set; } = new ProductDetail();
        public Brand brand { get; set; } = new Brand();
        public Category category { get; set; } = new Category();

    }
}
