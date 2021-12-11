namespace SPU911.Models
{
    public class ProductModel
    {
        public string ImageName { get; set; }
        public int SalePercent { get; set; }
        public bool IsNew { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOld { get; set; }
        public int Rate { get; set; }
        public ProductTypes ProductType { get; set; }
    }

}
