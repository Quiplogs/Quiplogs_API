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

        public async Task<SavedFile> UploadImageAsync(string container, string subContainter, string fileName, byte[] fileData, string mimeType)
        {
            return await UploadFileAsync(container, subContainter, fileName, fileData, mimeType, "images");
        }

        public async Task<SavedFile> UploadDocumentAsync(string container, string subContainter, string fileName, byte[] fileData, string mimeType)
        {
            return await UploadFileAsync(container, subContainter, fileName, fileData, mimeType, "document");
        }


        private async Task<SavedFile> UploadFileAsync(string container, string subContainter, string fileName, byte[] fileData, string mimeType, string documentType)
        {
            var result = new SavedFile();

            var cloudBlobContainer = CloudBlobClient.GetContainerReference($"{documentType}");
            if (await cloudBlobContainer.CreateIfNotExistsAsync())
            {
                await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            try
            {
                if (fileData != null)
                {
                    string generatedFileName = this.GenerateFileName(container, subContainter, fileName);
                    var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(generatedFileName);
                    cloudBlockBlob.Properties.ContentType = mimeType;
                    await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);

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

        public async void DeleteBlobImage(string container, string subContainter, string fileName)
        {
            DeleteBlobData("images", container, subContainter, fileName);
        }

        public async void DeleteBlobDocument(string container, string subContainter, string fileName)
        {
            DeleteBlobData("documents", container, subContainter, fileName);
        }

        private async void DeleteBlobData(string documentType, string container, string subContainter, string fileName)
        {
            try
            {
                var cloudBlobContainer = CloudBlobClient.GetContainerReference(documentType);
                var blobDirectory = cloudBlobContainer.GetDirectoryReference($"{container}/{subContainter}");
                var blockBlob = blobDirectory.GetBlockBlobReference(fileName);
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
