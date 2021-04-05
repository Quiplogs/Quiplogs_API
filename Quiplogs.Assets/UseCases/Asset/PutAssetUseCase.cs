using Quiplogs.Assets.Data.Entities;
using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class PutAssetUseCase : IPutUseCase<Domain.Entities.Asset, AssetDto>
    {
        private readonly IBaseRepository<Domain.Entities.Asset, AssetDto> _baseRepository;
        private readonly IBlobStorage _blobStorage;

        public PutAssetUseCase(
            IBaseRepository<Domain.Entities.Asset,
                AssetDto> baseRepository,
            IBlobStorage blobStorage)
        {
            _baseRepository = baseRepository;
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.Asset> request, IOutputPort<PutResponse<Domain.Entities.Asset>> outputPort)
        {
            var responseImageUnsaved = await _baseRepository.Put(request.Model);

            if (responseImageUnsaved.Success)
            {
                //persist to blob storage
                var persistedBlob = await _blobStorage.UploadImageAsync(new SaveFileRequest
                {
                    Container = responseImageUnsaved.Model.CompanyId.ToString(),
                    SubContainer = responseImageUnsaved.Model.Id.ToString(),
                    FileName = request.Model.ImageFileName,
                    FileBase64 = request.Model.ImageBase64,
                    MimeType = request.Model.ImageMimeType
                });

                responseImageUnsaved.Model.ImageUrl = persistedBlob.FileUrl;
                var responseImageSaved = await _baseRepository.Put(responseImageUnsaved.Model);

                if (responseImageSaved.Success)
                {
                    outputPort.Handle(new PutResponse<Domain.Entities.Asset>(responseImageSaved.Model, true));
                    return true;
                }

                outputPort.Handle(new PutResponse<Domain.Entities.Asset>(responseImageSaved.Errors));
                return false;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.Asset>(responseImageUnsaved.Errors));
            return false;
        }
    }
}
