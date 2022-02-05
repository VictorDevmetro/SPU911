using SPU911.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPU911.Services
{
    public interface IImageDALService
    {
        Task<ImageEntity> Add(string imageName);
        Task<ImageEntity> Get(int id);
        Task<IList<ImageEntity>> GetLIst();
    }
}