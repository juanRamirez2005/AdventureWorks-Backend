namespace WebApi.models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string ParentProductCategotyID { get; set; }
        public string Name { get; set; }
    }
}
