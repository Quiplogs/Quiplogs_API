using Quiplogs.BlobStorage.Models;
using System.Threading.Tasks;

namespace Quiplogs.BlobStorage
{
    public interface IBlobStorage
    {
        Task<SaveFileResponse> UploadImageAsync(SaveFileRequest request);

        Task<SaveFileResponse> UploadDocumentAsync(SaveFileRequest request);

        void DeleteBlobImage(DeleteFileRequest request);

        void DeleteBlobDocument(DeleteFileRequest request);
    }
}
