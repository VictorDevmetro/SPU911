using System.Collections.Generic;

namespace SPU911.Services
{
    public interface IWishListService
    {
        int Count();
        IList<int> GetWishList();
        void ToggleWishList(int id);

    }
}