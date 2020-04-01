using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Responses.BlobStorage;

namespace Quiplogs.Core.Dto.Requests.BlobStorage
{
    public class RemoveFileRequest : IRequest<RemoveFileResponse>
    {
        public string FileName { get; set; }
        public string ApplicationType { get; set; }
        public RemoveFileRequest(string fileName, string applicationType)
        {
            FileName = fileName;
            ApplicationType = applicationType;
        }
    }
}
