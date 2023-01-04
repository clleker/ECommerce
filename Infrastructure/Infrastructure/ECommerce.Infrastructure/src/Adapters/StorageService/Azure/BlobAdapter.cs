using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ECommerce.Application.Services.Storage.Azure;
using ETicaretAPI.Infrastructure.Services.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace ECommerce.Infrastructure.Adapters.StorageService.Azure
{
    public class BlobAdapter : Storage, IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _contanerName;
        private IConfiguration _configuration;

        private BlobContainerClient _blobContainerClient;
     
        public BlobAdapter(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Azure:BlobStorage:ConnectionString"]);
            _contanerName = configuration["Azure:BlobStorage:ConnectionString"];//TODO CONTAİNER NAME APPJSON'DAN ALINACAK
            _configuration = configuration;
        }

        public string GetBlobAddress() => _configuration["Azure:BlobStorage:Address"];

        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(containerName, file.FileName, HasFile);

                BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);

                //TODO You must convert that to generic 
                var blobHttpHeader = new BlobHttpHeaders { ContentType = "image/jpeg" };

                await blobClient.UploadAsync(file.OpenReadStream(),new BlobUploadOptions { HttpHeaders = blobHttpHeader });
                datas.Add((fileNewName, $"{containerName}/{fileNewName}"));
            }
            return datas;
        }
    }
}
