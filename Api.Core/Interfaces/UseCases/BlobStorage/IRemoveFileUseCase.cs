using Api.Core.Interfaces;
using Quiplogs.Core.Dto.Requests.BlobStorage;
using Quiplogs.Core.Dto.Responses.BlobStorage;

namespace Quiplogs.Core.Interfaces.UseCases.FileRemove
{
    public interface IRemoveFileUseCase : IRequestHandler<RemoveFileRequest, RemoveFileResponse>
    {
    }
}
