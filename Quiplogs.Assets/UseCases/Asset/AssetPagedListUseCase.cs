using System.Threading.Tasks;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class AssetPagedListUseCase : IPagedListUseCase<Domain.Entities.Asset, AssetDto>
    {
        private readonly IBaseRepository<Domain.Entities.Asset, AssetDto> _baseRepository;

        public AssetPagedListUseCase(IBaseRepository<Domain.Entities.Asset, AssetDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PagedRequest<Domain.Entities.Asset> request, IOutputPort<PagedResponse<Domain.Entities.Asset>> outputPort)
        {
            _baseRepository.BaseQuery(model => !request.LocationId.HasValue || model.LocationId == request.LocationId.Value, model => model.Location);

            var response = await _baseRepository.PagedList(_baseRepository.BaseQuery(model => !request.LocationId.HasValue || model.LocationId == request.LocationId.Value, model => model.Location),request.CompanyId, request.PageNumber, request.PageSize);
            if (response.Success)
            {
                outputPort.Handle(new PagedResponse<Domain.Entities.Asset>(response.PagedResult, true));
                return true;
            }

            outputPort.Handle(new PagedResponse<Domain.Entities.Asset>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
