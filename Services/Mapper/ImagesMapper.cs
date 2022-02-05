using SPU911.DAL.Entities;
using SPU911.Models;
using System;
using System.IO;

namespace SPU911.Services.Mapper
{
    public static class ImagesMapper
    {
        public static ImageModel Create(ImageEntity entity)
        {
            var  url = new Uri(entity.ImageUrl);
            string name = Path.GetFileName(url.AbsolutePath);

            return new ImageModel
            {
                Id = entity.Id,
                Url = entity.ImageUrl,
                Name = name,
            };
        }
    }
}
