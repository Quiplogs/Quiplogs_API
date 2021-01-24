using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Responses.Asset;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class GetAssetUseCase : IGetAssetUseCase
    {
        private readonly IAssetRepository _repository;

        public GetAssetUseCase(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetAssetRequest message, IOutputPort<GetAssetResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetAssetResponse(response.Asset, true));
                return true;
            }

            outputPort.Handle(new GetAssetResponse(new[] { new Error("", "Asset not Found.") }));
            return false;
        }
    }
}
