using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Inventory.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Part
{
    public class PutPartUseCase : IPutUseCase<Domain.Entities.Part, PartDto>
    {
        private readonly IBaseRepository<Domain.Entities.Part, PartDto> _baseRepository;
        private readonly IBlobRepository _blobRepository;

        public PutPartUseCase(
            IBaseRepository<Domain.Entities.Part,
                PartDto> baseRepository,
            IBlobRepository blobRepository)
        {
            _baseRepository = baseRepository;
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.Part> request, IOutputPort<PutResponse<Domain.Entities.Part>> outputPort)
        {
            // Check if existing model with same Code
            if (request.Model.Id == Guid.Empty)
            {
                var getResponse =
                    await _baseRepository.GetByCustomWhere(where => where.Code.Contains(request.Model.Code));
                if (getResponse.Success)
                {
                    outputPort.Handle(new PutResponse<Domain.Entities.Part>(new[]
                        {new Error("exists", $"Part with Code: '{request.Model.Code}' already exists.")}));
                    return false;
                }
            }

            var persistedModel = await _baseRepository.Put(request.Model);

            if (persistedModel.Success)
            {
                try
                {
                    //persist to blob storage
                    var blob = new Blob
                    {
                        ApplicationType = "part",
                        Base64 = request.Model.ImageBase64,
                        CompanyId = request.Model.CompanyId,
                        FileName = request.Model.ImageFileName,
                        ForeignKeyId = persistedModel.Model.Id,
                        MimeType = request.Model.ImageMimeType
                    };

                    await _blobRepository.PersistBlob(blob);
                }
                catch (Exception ex)
                {
                    outputPort.Handle(new PutResponse<Domain.Entities.Part>(new Error[] { new Error("blob_persist", $"{ex.Message}") }));
                    return false;
                }

                outputPort.Handle(new PutResponse<Domain.Entities.Part>(persistedModel.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.Part>(persistedModel.Errors));
            return false;
        }
    }
}
