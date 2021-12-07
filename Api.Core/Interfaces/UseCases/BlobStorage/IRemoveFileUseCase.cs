using Quiplogs.Core.Dto.Requests.BlobStorage;
using Quiplogs.Core.Dto.Responses.BlobStorage;

namespace Quiplogs.Core.Interfaces.UseCases.BlobStorage
{
    public interface IRemoveFileUseCase : IRequestHandler<RemoveFileRequest, RemoveFileResponse>
    {
    }
}
