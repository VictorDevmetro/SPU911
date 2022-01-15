using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SPU911.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ImageName { get { return $"product0{Id % 9 + 1}.png"; } }

        [DisplayName("Sale Percent")]
        [Range(0, 100, ErrorMessage = "Значення повинні лежати в межах 0 до 100")]
        public int SalePercent { get; set; }

        [DisplayName("This is a new product")]
        public bool IsNew { get; set; }

        [DisplayName("Category name")]
        //[EmailAddress]
        [Phone(ErrorMessage = "phone number")]
        public string CategoryName { get; set; }

        [DisplayName("Product name")]
        [Required(ErrorMessage = "Вкажіть назву продукта")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "максимум 20 символів")]
        [RegularExpression(@"[A-Za-z0-9 ]+", ErrorMessage = "Тільки латинські букви")]
        public string ProductName { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Ціна повина бути більша 0")]
        public decimal Price { get; set; }

        [DisplayName("Old price")]
        [Compare(nameof(Price), ErrorMessage = "ціни повинні співпадати")]
        public decimal PriceOld { get; set; }

        [Range(0, 6, ErrorMessage = "значення повинно лежати в межах від 0 до 5")]
        public int Rate { get; set; }

        [DisplayName("Product type")]
        public ProductTypes ProductType { get; set; }

        //[CreditCard(ErrorMessage ="Creadit card")]
        [DataType(DataType.CreditCard)]
        public string Details { get; set; }


        [DataType(DataType.Date, ErrorMessage = "wrong data")]
        public string CreateDate { get; set; }

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

        public bool InWishList { get; set; }
    }


    public class AjaxProductModel
    {
        public int Id { get; set; }
        public string ImageName { get { return $"product0{Id % 9 + 1}.png"; } }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

    }

}
