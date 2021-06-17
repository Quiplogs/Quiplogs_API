using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System;
using System.Threading.Tasks;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.UseCases.BlobStorage
{
    public class RemoveBlobUseCase
    {
        private readonly IBlobRepository _blobRepository;

        public RemoveBlobUseCase(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(Guid foreignKeyId, string applicationType, IOutputPort<RemoveResponse> outputPort)
        {
            try
            {
                await _blobRepository.RemoveBlobImage(foreignKeyId, applicationType);

                outputPort.Handle(new RemoveResponse("Removed Successfully", true));
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new RemoveResponse(new Error[] { new Error("remove_blob_image_error", $"{ex.Message}") }));
                return false;

            }
        }
    }
}
