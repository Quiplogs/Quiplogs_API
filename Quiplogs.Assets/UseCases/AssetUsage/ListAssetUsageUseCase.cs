using Api.Core;
using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Assets.Dto.Requests.AssetUsage;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.AssetUsage
{
    public class ListAssetUsageUseCase : IListAssetUsageUseCase
    {
        private readonly IAssetUsageRepository _repository;

        public ListAssetUsageUseCase(IAssetUsageRepository Repository)
        {
            _repository = Repository;
        }

        public async Task<bool> Handle(ListAssetUsageRequest message, IOutputPort<ListAssetUsageResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.GetAll(message.AssetId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.AssetId);
                var pagedResult = new PagedResult<Domain.Entities.AssetUsage>(response.AssetUsageList, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListAssetUsageResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListAssetUsageResponse(new[] { new Error("", "No Asset Usage Found.") }));
            return false;
        }
    }
}
