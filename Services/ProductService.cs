using Microsoft.EntityFrameworkCore;
using SPU911.DAL;
using SPU911.DAL.Entities;
using SPU911.Models;
using SPU911.Services.Mapper;
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
        //private IList<ProductModel> _products;

        private readonly ApplicationDBContext _dbContext;
        private readonly IWishListService _wishListService;

        public IList<ProductModel> Products
        {
            get
            {
                return _dbContext.Products
                    .Include(x => x.ImageItem)
                    .Select(ProductMapper.Create).ToList();
            }
        }

        public ProductService(IWishListService service, ApplicationDBContext dbContext)
        {


            _wishListService = service;
            _dbContext = dbContext;
        }

        public IList<ProductModel> GetAllProducts(string searchQuery = null, ProductTypes? productType = null)
        {
            var list = Products;

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
            return ProductMapper.Create(_dbContext.Products.Include(x => x.ImageItem).FirstOrDefault(x => x.Id == id));
        }
        public IList<ProductModel> GetProductsByType(ProductTypes type = ProductTypes.Laptops)
        {
            return _dbContext.Products.Include(x => x.ImageItem).Where(x => x.ProductType == type && x.IsNew)
                .Select(ProductMapper.Create)
                .ToList();
        }

        public IList<AjaxProductModel> GetWishList()
        {
            var wishList = _wishListService.GetWishList();
            var list = _dbContext.Products.Where(x => wishList.Contains(x.Id))
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
            ProductEntity entity = null;

            if (model.Id == default)
            {
                entity = ProductMapper.Create(model);
                entity = _dbContext.Products.Add(entity).Entity;
                _dbContext.SaveChanges();
                return ProductMapper.Create(entity);
            }

            try
            {
                entity = _dbContext.Products.Include(x => x.ImageItem).FirstOrDefault(x => x.Id == model.Id);
                entity = ProductMapper.Update(entity, model);

            }
            catch (Exception)
            {
                return null;
                //throw new Exception("Not found");
            }

            _dbContext.SaveChanges();
            return ProductMapper.Create(entity);
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
