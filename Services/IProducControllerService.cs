using SPU911.Models;
using System.Collections.Generic;

namespace SPU911.Services
{
    public interface IProducControllerService
    {
        ProductModel GetProduct(int id);

        IList<ProductModel> GetProductsByType(ProductTypes type = ProductTypes.Laptops);

    }
}
