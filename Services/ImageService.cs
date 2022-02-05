using Azure.Storage.Blobs;
using SPU911.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SPU911.Services
{
    public class ImageService : IImageService
    {
        private readonly BlobContainerClient _container;
        private readonly string _containerName = "images";

        public ImageService(BlobServiceClient client)
        {
            _container = client.GetBlobContainerClient(_containerName);
        }

        public async Task<ImageViewModel> GetFile(string fileName)
        {

            var blob = _container.GetBlobClient(fileName);
            var downloadInfo = await blob.DownloadAsync();
            using (var fileStream = new MemoryStream())
            {
                await downloadInfo.Value.Content.CopyToAsync(fileStream);
                var bytes = fileStream.ToArray();

                return new ImageViewModel
                {
                    Name = fileName,
                    Bytes = bytes,
                    ContentType = downloadInfo.Value.ContentType
                };
            }
        }

        public async Task<IList<string>> GetImages()
        {
            var list = _container.GetBlobsAsync();

            var result = new List<string>();
            await foreach (var item in list)
            {
                result.Add(item.Name);
            }

            return result;
        }

        public async Task<string> Upload(string fileName, Stream file)
        {

            fileName = $"{DateTime.UtcNow.Ticks}-{fileName}";

            //fileName = $"{Guid.NewGuid()}-{fileName}";

            var blob = _container.GetBlobClient(fileName);
            var response = await blob.UploadAsync(file);

            if (response.GetRawResponse().Status >= 400)
            {
                throw new System.Exception("Upload failed");
            }

            return fileName;
        }
    }
}
