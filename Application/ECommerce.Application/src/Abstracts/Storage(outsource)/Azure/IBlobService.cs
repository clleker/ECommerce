

namespace ECommerce.Application.Services.Storage.Azure
{
    public interface IBlobService : IStorage
    {
        ///// <summary>
        ///// Provides blob storage address.
        ///// </summary>
        ///// <returns>String.</returns>
        //string GetBlobStorageAddress();
         string GetBlobAddress();

        ///// <summary>
        ///// Provides blob storage urls.
        ///// </summary>
        ///// <param name="baseAddress">baseAddress.</param>
        ///// <param name="container">container.</param>
        ///// <returns>String.</returns>
        //List<string> GetBlobsUrls(string baseAddress, string container);
    }
}
