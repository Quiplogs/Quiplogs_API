using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Responses.Asset;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class RemoveAssetUseCase : IRemoveAssetUseCase
    {
        private readonly IAssetRepository _repository;

        public RemoveAssetUseCase(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveAssetRequest message, IOutputPort<RemoveAssetResponse> outputPort)
        {
            //var response = await _repository.Remove(message.Id);
            //if (response.Success)
            //{
            //    outputPort.Handle(new RemoveAssetResponse(response.AssetDescription, true));
            //    return true;
            //}

            outputPort.Handle(new RemoveAssetResponse(new[] { new Error("", "Error removing Asset.") }));
            return false;
        }
    }
}
