using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Inventory.Data.Entities;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Part
{
    public class PutPartUseCase : IPutUseCase<Domain.Entities.Part, PartDto>
    {
        private readonly IBaseRepository<Domain.Entities.Part, PartDto> _baseRepository;
        private readonly IBlobStorage _blobStorage;

        public PutPartUseCase(
            IBaseRepository<Domain.Entities.Part,
                PartDto> baseRepository,
            IBlobStorage blobStorage)
        {
            _baseRepository = baseRepository;
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.Part> request, IOutputPort<PutResponse<Domain.Entities.Part>> outputPort)
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
                    outputPort.Handle(new PutResponse<Domain.Entities.Part>(responseImage.Model, true));
                    return true;
                }
            }

            outputPort.Handle(new PutResponse<Domain.Entities.Part>(new[] { new Error("", "Error Updating Model.") }));
            return false;
        }
    }
}
