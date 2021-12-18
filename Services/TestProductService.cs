using SPU911.Models;
using System.Collections.Generic;

namespace SPU911.Services
{
    public class TestProductService : IProducControllerService
    {
        public ProductModel CreateOrUpdate(ProductModel model)
        {
            throw new System.NotImplementedException();
        }

        public ProductModel GetProduct(int id)
        {
            return new ProductModel
            {
                Id = id,
                SalePercent = 0,
                IsNew = true,
                CategoryName = "Cameras",
                ProductName = "Sony",
                Price = 5000,
                PriceOld = 6599,
                Rate = 3,
                ProductType = ProductTypes.Cameras
            };
        }

        public IList<ProductModel> GetProductsByType(ProductTypes type = ProductTypes.Laptops)
        {
            return new List<ProductModel> {
                new ProductModel{
                    Id = 1,
                    SalePercent = 0,
                    IsNew = true,
                    CategoryName = "Cameras",
                    ProductName = "Sony",
                    Price = 5000,
                    PriceOld = 6599,
                    Rate = 3,
                    ProductType = ProductTypes.Cameras
                }
            };
        }
    }
}
