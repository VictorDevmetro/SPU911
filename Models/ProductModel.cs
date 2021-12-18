using System.ComponentModel;

namespace SPU911.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ImageName { get { return $"product0{Id % 9 + 1}.png"; } }
        
        [DisplayName("Sale Percent")]
        public int SalePercent { get; set; }
        
        [DisplayName("This is a new product")]
        public bool IsNew { get; set; }
        
        [DisplayName("Category name")]
        public string CategoryName { get; set; }
        
        [DisplayName("Product name")]
        public string ProductName { get; set; }
        
        public decimal Price { get; set; }
        
        [DisplayName("Old price")]
        public decimal PriceOld { get; set; }
        
        public int Rate { get; set; }
        
        [DisplayName("Product type")]
        public ProductTypes ProductType { get; set; }
        
        public string Details { get; set; }

        public ProductModel()
        {
            Details = "Lorem ipsum dolor sit amet, consectetur adipisicing" +
                "elit, sed do eiusmod tempor incididunt ut labore et " +
                "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                "exercitation ullamco laboris nisi ut aliquip ex ea commodo" +
                " consequat.";
        }

        public override string ToString()
        {
            return ProductName;
        }
    }

}
