using Quiplogs.Assets.Data.Entities;
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
    public class RemoveAssetUseCase : IRemoveUseCase<Domain.Entities.Asset, AssetDto>
    {
        private readonly IBaseRepository<Domain.Entities.Asset, AssetDto> _baseRepository;
        private readonly IBlobRepository _blobRepository;

        public RemoveAssetUseCase(IBaseRepository<Domain.Entities.Asset, AssetDto> baseRepository,
            IBlobRepository blobRepository)
        {
            _baseRepository = baseRepository;
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(RemoveRequest request, IOutputPort<RemoveResponse> outputPort)
        {
            try
            {
                await _blobRepository.RemoveBlobImage(request.Id, "asset");
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
