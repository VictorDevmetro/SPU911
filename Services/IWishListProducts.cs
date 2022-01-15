using SPU911.Models;
using System.Collections.Generic;

namespace SPU911.Services
{
    public interface IWishListProducts
    {
        IList<AjaxProductModel> GetWishList();

    }
}