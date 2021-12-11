using SPU911.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPU911.Services
{
    public class ProductService
    {
        private IList<ProductModel> _products;

        public IList<ProductModel> Products { get { return _products; } }

        public ProductService()
        {
            _products = new List<ProductModel> {
                new ProductModel{
                    ImageName ="product01.png",
                    SalePercent =15,
                    IsNew = true,
                    CategoryName = "Headphones",
                    ProductName = "IPods",
                    Price = 500,
                    PriceOld = 625,
                    Rate = 4,
                    ProductType = ProductTypes.Accesories
                },

                new ProductModel{
                    ImageName ="product02.png",
                    SalePercent = 10,
                    IsNew = true,
                    CategoryName = "Laptops",
                    ProductName = "MacBook Air",
                    Price = 2000,
                    PriceOld = 2599,
                    Rate = 5,
                    ProductType = ProductTypes.Laptops
                },

                new ProductModel{
                    ImageName ="product03.png",
                    SalePercent = 5,
                    IsNew = true,
                    CategoryName = "Desktop",
                    ProductName = "ProBook",
                    Price = 5000,
                    PriceOld = 6599,
                    Rate = 5,
                    ProductType = ProductTypes.Laptops
                },
                new ProductModel{
                    ImageName ="product04.png",
                    SalePercent = 0,
                    IsNew = true,
                    CategoryName = "Cameras",
                    ProductName = "Sony",
                    Price = 5000,
                    PriceOld = 6599,
                    Rate = 3,
                    ProductType = ProductTypes.Cameras
                },

                new ProductModel{
                    ImageName ="product05.png",
                    SalePercent = 25,
                    IsNew = true,
                    CategoryName = "Calls",
                    ProductName = "MI Pro 10",
                    Price = 2300,
                    PriceOld = 2599,
                    Rate = 2,
                    ProductType = ProductTypes.SmartPhones
                },
                new ProductModel{
                    ImageName ="product06.png",
                    SalePercent = 5,
                    IsNew = true,
                    CategoryName = "Printer",
                    ProductName = "Epson L5136",
                    Price = 350,
                    PriceOld = 599,
                    Rate = 5,
                    ProductType = ProductTypes.Accesories
                },
            };
    }

    public IList<ProductModel> GetAllProducts() => _products;
    public IList<ProductModel> GetNewProducts(ProductTypes type = ProductTypes.Laptops)
    {
        return _products.Where(x => x.ProductType == type && x.IsNew).ToList();
    }

}
}
