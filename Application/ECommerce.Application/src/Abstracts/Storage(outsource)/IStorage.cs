using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        /// <summary>
        /// The method that deletes the file from the storage.
        /// </summary>
        /// <param name="pathOrContainerName">pathOrContainerName</param>
        /// <param name="fileName">fileName</param>
        /// <returns></returns>
        Task DeleteAsync(string pathOrContainerName, string fileName);

        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
