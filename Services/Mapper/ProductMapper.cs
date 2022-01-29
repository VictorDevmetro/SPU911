using SPU911.DAL.Entities;
using SPU911.Models;

namespace SPU911.Services.Mapper
{
    public static class ProductMapper
    {
        public static ProductModel Create(ProductEntity entity)
        {
            var imageUrl = entity.ImageItem?.ImageUrl;
            //if (imageUrl.Substring(0, 4) != "http")
            //{
            //    imageUrl = "~/" + imageUrl;
            //}
            return new ProductModel
            {
                Id = entity.Id,
                ImageName = imageUrl,
                SalePercent = entity.SalePercent,
                IsNew = entity.IsNew,
                CategoryName = entity.CategoryName,
                ProductName = entity.ProductName,
                Price = entity.Price,
                PriceOld = entity.PriceOld,
                Rate = entity.Rate,
                ProductType = entity.ProductType,
                CreateDate = entity.CreateDate
            };
        }

        public static ProductEntity Create(ProductModel model)
        {
            return new ProductEntity
            {
                //ImageName = model.ImageItem.ImageUrl,
                SalePercent = model.SalePercent,
                IsNew = model.IsNew,
                CategoryName = model.CategoryName,
                ProductName = model.ProductName,
                Price = model.Price,
                PriceOld = model.PriceOld,
                Rate = model.Rate,
                ProductType = model.ProductType,
                CreateDate = model.CreateDate
            };
        }

        public static ProductEntity Update(ProductEntity entity, ProductModel model)
        {

            //ImageName = model.ImageItem.ImageUrl,
            entity.SalePercent = model.SalePercent;
            entity.IsNew = model.IsNew;
            entity.CategoryName = model.CategoryName;
            entity.ProductName = model.ProductName;
            entity.Price = model.Price;
            entity.PriceOld = model.PriceOld;
            entity.Rate = model.Rate;
            entity.ProductType = model.ProductType;
            entity.CreateDate = model.CreateDate;

            return entity;
        }
    }
}
