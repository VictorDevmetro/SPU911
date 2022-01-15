using System;
using System.Collections.Generic;

namespace SPU911.Services
{
    public class WishListService : IWishListService
    {
        private Dictionary<Guid, IList<int>> advancedWishList = new Dictionary<Guid, IList<int>>();

        private IList<int> _ids = new List<int>();

        public void ToggleWishList(int id)
        {
            if (_ids.Contains(id))
            {
                _ids.Remove(id);
            }
            else
            {
                _ids.Add(id);
            }
        }

        public IList<int> GetWishList()
        {
            return _ids;
        }

        public int Count()
        {
            return _ids.Count;
        }
    }
}
