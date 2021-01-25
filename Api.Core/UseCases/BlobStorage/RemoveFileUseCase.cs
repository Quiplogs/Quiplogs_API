using System;
using System.Threading.Tasks;
using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Dto.Requests.BlobStorage;
using Quiplogs.Core.Dto.Responses.BlobStorage;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.BlobStorage;

namespace Quiplogs.Core.UseCases.BlobStorage
{
    public class RemoveFileUseCase : IRemoveFileUseCase
    {
        private readonly IBlobStorage _blobStorage;
        private readonly ILocationRepository _locationRepository; 
        public RemoveFileUseCase(IBlobStorage blobStorage, ILocationRepository locationRepository)
        {
            _blobStorage = blobStorage;
            _locationRepository = locationRepository;
        }

        public async Task<bool> Handle(RemoveFileRequest message, IOutputPort<RemoveFileResponse> outputPort)
        {
            try
            {
                var splitFileName = message.FileName.Split("/");
                if (splitFileName != null)
                {
                    _blobStorage.DeleteBlobImage(new DeleteFileRequest
                    {
                        Container = splitFileName[0],
                        SubContainer = splitFileName[1],
                        FileName = splitFileName[2]
                    });

                    if (message.ApplicationType == "location")
                    {
                        await _locationRepository.RemoveImage(Guid.Parse(splitFileName[1]));
                    }

                    outputPort.Handle(new RemoveFileResponse($"{message.FileName} has been removed succesfully", true));
                    return true;
                }
                else
                {
                    //outputPort.Handle(new RemoveFileResponse(new[] { new Error(GlobalVariables.error_locationFailure, "Error removing file.") }));
                    return false;
                }
            }
            catch(Exception ex)
            {
                //outputPort.Handle(new RemoveFileResponse(new[] { new Error(GlobalVariables.error_locationFailure, "Error removing file.") }));
                return false;
            }
        }
    }
}
