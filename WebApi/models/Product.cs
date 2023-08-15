namespace WebApi.models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
    }
}
