using SPU911.Models;
using System.Collections.Generic;

namespace SPU911.ViewModel
{
    public class ProductDetailsViewModel
    {
        public ProductModel  Product { get; set; }
        public IList<ProductModel> RelatedProducts { get; set; }
    }
}
