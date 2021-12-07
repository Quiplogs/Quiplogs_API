using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Core.UseCases.Location
{
    public class PutLocationUseCase : IPutUseCase<Domain.Entities.Location, LocationDto>
    {
        private readonly IBaseRepository<Domain.Entities.Location, LocationDto> _baseRepository;
        private readonly IBlobRepository _blobRepository;

        public PutLocationUseCase(
            IBaseRepository<Domain.Entities.Location,
                LocationDto> baseRepository,
            IBlobRepository blobRepository)
        {
            _baseRepository = baseRepository;
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.Location> request, IOutputPort<PutResponse<Domain.Entities.Location>> outputPort)
        {
            var persistedModel = await _baseRepository.Put(request.Model);

            if (persistedModel.Success)
            {
                try
                {
                    //persist to blob storage
                    var blob = new Blob
                    {
                        ApplicationType = "location",
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
                    outputPort.Handle(new PutResponse<Domain.Entities.Location>(new Error[] { new Error("blob_persist", $"{ex.Message}") }));
                    return false;
                }

                outputPort.Handle(new PutResponse<Domain.Entities.Location>(persistedModel.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.Location>(persistedModel.Errors));
            return false;
        }
    }
}
