using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Responses.Asset;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class FetchAssetUseCase : IFetchAssetUseCase
    {
        private readonly IAssetRepository _AssetRepository;

        public FetchAssetUseCase(IAssetRepository AssetRepository)
        {
            _AssetRepository = AssetRepository;
        }

        public async Task<bool> Handle(FetchAssetRequest message, IOutputPort<FetchAssetResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _AssetRepository.GetAll(message.CompanyId, message.LocationId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _AssetRepository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.Asset>(response.Assets, total, message.PageNumber, pageSize);

                outputPort.Handle(new FetchAssetResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new FetchAssetResponse(new[] { new Error(GlobalVariables.error_assetFailure, "No Asset Found.") }));
            return false;
        }
    }
}
