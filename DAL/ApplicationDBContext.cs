using Microsoft.EntityFrameworkCore;
using SPU911.DAL.Entities;
using SPU911.Models;

namespace SPU911.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ImageEntity> Images { get; set; }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageEntity>().HasData(
                new ImageEntity { Id = 1, ImageUrl = "img/product01.png" },
                new ImageEntity { Id = 2, ImageUrl = "img/product02.png" },
                new ImageEntity { Id = 3, ImageUrl = "img/product03.png" },
                new ImageEntity { Id = 4, ImageUrl = "img/product04.png" },
                new ImageEntity { Id = 5, ImageUrl = "img/product05.png" },
                new ImageEntity { Id = 6, ImageUrl = "img/product06.png" },
                new ImageEntity { Id = 7, ImageUrl = "img/product07.png" },
                new ImageEntity { Id = 8, ImageUrl = "img/product08.png" },
                new ImageEntity { Id = 9, ImageUrl = "img/product09.png" }
                );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity
                {
                    Id = 1,
                    SalePercent = 15,
                    IsNew = false,
                    CategoryName = "Headphones",
                    ProductName = "IPods",
                    Price = 500,
                    PriceOld = 625,
                    Rate = 4,
                    ProductType = ProductTypes.Accesories,
                    ImageId = 1,
                },

                                new ProductEntity
                                {
                    Id = 2,
                                    SalePercent = 0,
                                    IsNew = true,
                                    CategoryName = "Laptops",
                                    ProductName = "MacBook Air",
                                    Price = 2000,
                                    PriceOld = 2599,
                                    Rate = 5,
                                    ProductType = ProductTypes.Laptops,
                                    ImageId = 2,

                                },
                new ProductEntity
                {
                    Id = 3,
                    SalePercent = 5,
                    IsNew = true,
                    CategoryName = "Desktop",
                    ProductName = "ProBook",
                    Price = 5000,
                    PriceOld = 6599,
                    Rate = 5,
                    ProductType = ProductTypes.Laptops,
                    ImageId = 3,
                },
                new ProductEntity
                {
                    Id = 4,
                    SalePercent = 0,
                    IsNew = true,
                    CategoryName = "Cameras",
                    ProductName = "Sony",
                    Price = 5000,
                    PriceOld = 6599,
                    Rate = 3,
                    ProductType = ProductTypes.Cameras,
                    ImageId = 4,

                },
                new ProductEntity
                {
                    Id = 5,
                    SalePercent = 25,
                    IsNew = true,
                    CategoryName = "Calls",
                    ProductName = "MI Pro 10",
                    Price = 2300,
                    PriceOld = 2599,
                    Rate = 2,
                    ProductType = ProductTypes.SmartPhones,
                    ImageId = 5,

                },
                new ProductEntity
                {
                    Id = 6,
                    SalePercent = 5,
                    IsNew = true,
                    CategoryName = "Printer",
                    ProductName = "Epson L5136",
                    Price = 350,
                    PriceOld = 599,
                    Rate = 5,
                    ProductType = ProductTypes.Accesories,
                    ImageId = 6,

                }

                );
        }

    }
}
