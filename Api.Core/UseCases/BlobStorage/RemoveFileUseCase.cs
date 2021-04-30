using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.BlobStorage;
using Quiplogs.Core.Dto.Responses.BlobStorage;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.UseCases.BlobStorage;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Core.UseCases.BlobStorage
{
    public class RemoveFileUseCase : IRemoveFileUseCase
    {
        private readonly IBlobStorage _blobStorage;

        public RemoveFileUseCase(IBlobStorage blobStorage)
        {
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(RemoveFileRequest message, IOutputPort<RemoveFileResponse> outputPort)
        {
            try
            {
                var splitFileName = message.FileName.Split("/");
                await _blobStorage.DeleteBlobImage(new DeleteFileRequest
                {
                    Container = splitFileName[0],
                    SubContainer = splitFileName[1],
                    FileName = splitFileName[2]
                });

                outputPort.Handle(new RemoveFileResponse($"{message.FileName} has been removed successfully", true));
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new RemoveFileResponse(new[] { new Error("Delete Image Failure", ex.Message) }));
            }

            return false;
        }
    }
}
