namespace WebApplication8.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }

        public int oldPrice { get; set; }
        public int discount { get; set; }
    }
}
