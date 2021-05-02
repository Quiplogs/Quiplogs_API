using System;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;

namespace Quiplogs.Core.UseCases.BlobStorage
{
    public class GetBlobUseCase
    {
        private readonly IBlobRepository _blobRepository;

        public GetBlobUseCase(IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(Guid foreignKeyId, string applicationType, IOutputPort<GetResponse<Blob>> outputPort)
        {
            try
            {
                var model = await _blobRepository.Get(foreignKeyId, applicationType) ?? new Blob();
                outputPort.Handle(new GetResponse<Domain.Entities.Blob>(model, true));
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new GetResponse<Domain.Entities.Blob>(new Error[] { new Error("GetBlob", $"{ex.Message}") }));
                return false;

            }
        }
    }
}
