using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Quiplogs.BlobStorage.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Quiplogs.BlobStorage
{
    public class BlobStorage : IBlobStorage
    {
        private static IConfiguration Configuration;
        private string ConnectionString;
        private CloudStorageAccount CloudStorageAccount;
        private CloudBlobClient CloudBlobClient;

        public BlobStorage(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("BlobStorage");
            CloudStorageAccount = CloudStorageAccount.Parse(ConnectionString);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        public async Task<SaveFileResponse> UploadImageAsync(SaveFileRequest request)
        {
            return await UploadFileAsync(request, "images");
        }

        public async Task<SaveFileResponse> UploadDocumentAsync(SaveFileRequest request)
        {
            return await UploadFileAsync(request, "document");
        }


        private async Task<SaveFileResponse> UploadFileAsync(SaveFileRequest request, string documentType)
        {
            var result = new SaveFileResponse();

            var cloudBlobContainer = CloudBlobClient.GetContainerReference($"{documentType}");
            if (await cloudBlobContainer.CreateIfNotExistsAsync())
            {
                await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            try
            {
                if (!string.IsNullOrEmpty(request.FileBase64))
                {
                    string[] splitBase64 = request.FileBase64.Split(",");
                    var byteArray = Convert.FromBase64String(splitBase64[1]);

                    string generatedFileName = this.GenerateFileName(request.Container, request.SubContainer, request.FileName);
                    var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(generatedFileName);
                    cloudBlockBlob.Properties.ContentType = request.MimeType;
                    await cloudBlockBlob.UploadFromByteArrayAsync(byteArray, 0, byteArray.Length);

                    result.FileName = generatedFileName;
                    result.FileUrl = cloudBlockBlob.Uri.AbsoluteUri;
                }
            }
            catch (Exception ex)
            {
                //log to nlog
            }

            return result;
        }

        public async void DeleteBlobImage(DeleteFileRequest request)
        {
            await DeleteBlobData(request, "images");
        }

        public async void DeleteBlobDocument(DeleteFileRequest request)
        {
            await DeleteBlobData(request, "documents");
        }

        private async Task DeleteBlobData(DeleteFileRequest request, string documentType)
        {
            try
            {
                var cloudBlobContainer = CloudBlobClient.GetContainerReference(documentType);
                var blobDirectory = cloudBlobContainer.GetDirectoryReference($"{request.Container}/{request.SubContainer}");
                var blockBlob = blobDirectory.GetBlockBlobReference(request.FileName);
                await blockBlob.DeleteAsync();
            }
            catch (Exception ex)
            {
                //log to nlog
            }
        }


        private string GenerateFileName(string container, string subContainter, string fileName)
        {
            return $"{container}/{subContainter}/{fileName}";
        }
    }
}
