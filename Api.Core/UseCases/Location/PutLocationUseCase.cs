using System;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;
using Quiplogs.BlobStorage;

namespace Quiplogs.Core.UseCases.Location
{
    public class PutLocationUseCase : IPutUseCase<Domain.Entities.Location, LocationDto>
    {
        private readonly IBaseRepository<Domain.Entities.Location, LocationDto> _baseRepository;
        private readonly IBlobStorage _blobStorage;

        public PutLocationUseCase(
            IBaseRepository<Domain.Entities.Location,
            LocationDto> baseRepository,
            IBlobStorage blobStorage)
        {
            _baseRepository = baseRepository;
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.Location> request, IOutputPort<PutResponse<Domain.Entities.Location>> outputPort)
        {
            var responseImageUnsaved = await _baseRepository.Put(request.Model);
            
            if (responseImageUnsaved.Success)
            {
                //persist to blob storage
                var saveBlobRequest = new SaveFileRequest
                {
                    Container = responseImageUnsaved.Model.CompanyId.ToString(),
                    SubContainer = responseImageUnsaved.Model.Id.ToString(),
                    FileName = request.Model.ImageFileName,
                    FileBase64 = request.Model.ImageBase64,
                    MimeType = request.Model.ImageMimeType
                };

                var persistedBlob = await _blobStorage.UploadImageAsync(saveBlobRequest);

                responseImageUnsaved.Model.ImageUrl = persistedBlob.FileUrl;

                var responseImage = await _baseRepository.Put(responseImageUnsaved.Model);

                if (responseImage.Success)
                {
                    outputPort.Handle(new PutResponse<Domain.Entities.Location>(responseImage.Model, true));
                    return true;
                }
            }

            outputPort.Handle(new PutResponse<Domain.Entities.Location>(new[] { new Error("", "Error Updating Model.") }));
            return false;
        }
    }
}
