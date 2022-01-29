using SPU911.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPU911.DAL.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int SalePercent { get; set; }
        public bool IsNew { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOld { get; set; }
        public int Rate { get; set; }
        public ProductTypes ProductType { get; set; }
        public string CreateDate { get; set; }
        //public bool InWishList { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual ImageEntity ImageItem { get; set; }

    }
}
