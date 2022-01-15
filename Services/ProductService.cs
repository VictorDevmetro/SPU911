using SPU911.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPU911.Services
{
    public class ProductService :
        IProductCommonService,
        IProducControllerService,
        IHomeControllerProductService,
        ICRUDService<ProductModel>,
        IWishListProducts
    {
        private IList<ProductModel> _products;

        private readonly IWishListService _wishListService;

        public IList<ProductModel> Products { get { return _products; } }

        public ProductService(IWishListService service)
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
                _products[i - 1].Id = i;
            }

            _wishListService = service;

        }

        public IList<ProductModel> GetAllProducts(string searchQuery = null, ProductTypes? productType = null)
        {
            var list = _products;

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                list = list.Where(x => x.ProductName.Contains(searchQuery, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            if (list.Count > 0 && productType.HasValue)
            {
                list = list.Where(x => x.ProductType == productType.Value).ToList();
            }

            var wishList = _wishListService.GetWishList();
            foreach (var item in list)
            {
                item.InWishList = wishList.Contains(item.Id);
            }

            return list;
        }
        public ProductModel GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }
        public IList<ProductModel> GetProductsByType(ProductTypes type = ProductTypes.Laptops)
        {
            return _products.Where(x => x.ProductType == type && x.IsNew).ToList();
        }

        public IList<AjaxProductModel> GetWishList()
        {
            var wishList = _wishListService.GetWishList();
            var list = _products.Where(x => wishList.Contains(x.Id))
                .Select(x => new AjaxProductModel
                {
                    Id = x.Id,
                    Price = x.Price,
                    ProductName = x.ProductName
                }).ToList();

            return list;
        }

        public ProductModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductModel CreateOrUpdate(ProductModel model)
        {
            if (model.Id == default)
            {
                model.Id = _products.Count + 1;
                _products.Add(model);
                return model;
            }

            try
            {
                _products[model.Id-1] = model;

            }
            catch (Exception)
            {
                return null;
                //throw new Exception("Not found");
            }
            return model;
        }

        public bool Delete(ProductModel item)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProductCommonService
    {
        IList<ProductModel> GetAllProducts(string searchQuery = null, ProductTypes? productType = null);
        ProductModel GetProduct(int id);
        IList<ProductModel> GetProductsByType(ProductTypes type = ProductTypes.Laptops);
        ProductModel CreateOrUpdate(ProductModel item);
    }

    public interface ICRUDService<T>
    {
        T Get(int id);
        IList<T> GetAll();
        T CreateOrUpdate(T item);
        bool Delete(T item);

    }

}
