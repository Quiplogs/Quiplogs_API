using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class PutAssetUseCase : IPutUseCase<Domain.Entities.Asset, AssetDto>
    {
        private readonly IBaseRepository<Domain.Entities.Asset, AssetDto> _baseRepository;
        private readonly IBlobRepository _blobRepository;

        public PutAssetUseCase(
            IBaseRepository<Domain.Entities.Asset,
                AssetDto> baseRepository,
            IBlobRepository blobRepository)
        {
            _baseRepository = baseRepository;
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(PutRequest<Domain.Entities.Asset> request, IOutputPort<PutResponse<Domain.Entities.Asset>> outputPort)
        {
            var persistedModel = await _baseRepository.Put(request.Model);

            if (persistedModel.Success)
            {
                try
                {
                    //persist to blob storage
                    var blob = new Blob
                    {
                        ApplicationType = "asset",
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
                    outputPort.Handle(new PutResponse<Domain.Entities.Asset>(new Error[] { new Error("blob_persist", $"{ex.Message}") }));
                    return false;
                }

                outputPort.Handle(new PutResponse<Domain.Entities.Asset>(persistedModel.Model, true));
                return true;
            }

            outputPort.Handle(new PutResponse<Domain.Entities.Asset>(persistedModel.Errors));
            return false;
        }
    }
}
