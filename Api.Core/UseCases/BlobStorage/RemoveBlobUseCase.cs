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
using Quiplogs.Core.Dto.Responses.Generic;

namespace Quiplogs.Core.UseCases.BlobStorage
{
    public class RemoveBlobUseCase : IRemoveUseCase<Domain.Entities.Blob, BlobEntity>
    {
        private readonly IBaseRepository<Domain.Entities.Blob, BlobEntity> _baseRepository;
        private readonly IBlobStorage _blobStorage;

        public RemoveBlobUseCase(IBaseRepository<Domain.Entities.Blob, BlobEntity> baseRepository, IBlobStorage blobStorage)
        {
            _baseRepository = baseRepository;
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(RemoveRequest request, IOutputPort<RemoveResponse> outputPort)
        {
            try
            {
                var getRequest = await _baseRepository.GetById(request.Id);

                await _blobStorage.DeleteBlobImage(new DeleteFileRequest
                {
                    Container = getRequest.Model.CompanyId.ToString(),
                    SubContainer = getRequest.Model.ForeignKeyId.ToString(),
                    FileName = getRequest.Model.FileName
                });

                await _baseRepository.Remove(request.Id);

                outputPort.Handle(new RemoveResponse("Successfully removed Blob", true));
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new RemoveResponse(new Error[] { new Error("BlobException", $"{ex.Message}") }));
                return false;
            }
        }
    }
}
