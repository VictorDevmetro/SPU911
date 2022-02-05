using SPU911.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SPU911.Services
{
    public interface IImageService
    {
        Task<IList<string>> GetImages();
        Task<string> Upload(string fileName, Stream file);
        Task<ImageViewModel> GetFile(string fileName);
    }
}