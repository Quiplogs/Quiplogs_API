using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Core.UseCases.BlobStorage
{
    public class PutBlobUseCase : IPutUseCase<Domain.Entities.Blob, BlobEntity>
    {
        private readonly IBaseRepository<Domain.Entities.Blob, BlobEntity> _baseRepository;

        public PutBlobUseCase(IBaseRepository<Domain.Entities.Blob, BlobEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.Blob> request, IOutputPort<PutResponse<Domain.Entities.Blob>> outputPort)
        {
            try
            {
                var model = await _baseRepository.Put(request.Model);

                if (model.Success)
                {
                    outputPort.Handle(new PutResponse<Domain.Entities.Blob>(model.Model, true));
                    return true;
                }
            }
            catch (Exception ex)
            {
                outputPort.Handle(new PutResponse<Domain.Entities.Blob>(new Error[] { new Error("BlobException", $"{ex.Message}") }));
                return false;
            }

            return false;
        }
    }
}
