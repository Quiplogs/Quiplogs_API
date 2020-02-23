using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Responses.Asset;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class PutAssetUseCase : IPutAssetUseCase
    {
        private readonly IAssetRepository _repository;

        public PutAssetUseCase(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutAssetRequest message, IOutputPort<PutAssetResponse> outputPort)
        {
            var response = await _repository.Put(message.Asset);
            if (response.Success)
            {
                outputPort.Handle(new PutAssetResponse(response.Asset, true));
                return true;
            }

            outputPort.Handle(new PutAssetResponse(new[] { new Error(GlobalVariables.error_assetFailure, "Error updating Asset.") }));
            return false;
        }
    }
}
