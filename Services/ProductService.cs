using SPU911.Models;
using System;
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
                    SalePercent =15,
                    IsNew = false,
                    CategoryName = "Headphones",
                    ProductName = "IPods",
                    Price = 500,
                    PriceOld = 625,
                    Rate = 4,
                    ProductType = ProductTypes.Accesories
                },

                new ProductModel{
                    SalePercent = 0,
                    IsNew = true,
                    CategoryName = "Laptops",
                    ProductName = "MacBook Air",
                    Price = 2000,
                    PriceOld = 2599,
                    Rate = 5,
                    ProductType = ProductTypes.Laptops
                },

                new ProductModel{
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

            for (int i = 1; i <= _products.Count; i++)
            {
                _products[i-1].Id = i;
            }
        }

        public IList<ProductModel> GetAllProducts() => _products;
        public ProductModel GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }
        public IList<ProductModel> GetProductsByType(ProductTypes type = ProductTypes.Laptops)
        {
            return _products.Where(x => x.ProductType == type && x.IsNew).ToList();
        }

    }
}
