using Quiplogs.BlobStorage.Models;
using System.Threading.Tasks;

namespace Quiplogs.BlobStorage
{
    public interface IBlobStorage
    {
        Task<SavedFile> UploadImageAsync(string container, string subContainter, string fileName, byte[] fileData, string mimeType);

        Task<SavedFile> UploadDocumentAsync(string container, string subContainter, string fileName, byte[] fileData, string mimeType);

        void DeleteBlobImage(string container, string subContainter, string fileName);

        void DeleteBlobDocument(string container, string subContainter, string fileName);
    }
}
