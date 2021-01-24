using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.AssetUsage;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.AssetUsage
{
    class RemoveAssetUsageUseCasee : IRemoveAssetUsageUseCase
    {
        private readonly IAssetUsageRepository _repository;

        public RemoveAssetUsageUseCasee(IAssetUsageRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveAssetUsageRequest message, IOutputPort<RemoveAssetUsageResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveAssetUsageResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemoveAssetUsageResponse(new[] { new Error("", "Error removing Asset Usage.") }));
            return false;
        }
    }
}
