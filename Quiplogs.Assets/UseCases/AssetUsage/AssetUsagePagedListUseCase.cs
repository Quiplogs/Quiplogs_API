using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.AssetUsage
{
    public class AssetUsagePagedListUseCase : IPagedListUseCase<Domain.Entities.AssetUsage, AssetUsageDto>
    {
        private readonly IBaseRepository<Domain.Entities.AssetUsage, AssetUsageDto> _baseRepository;

        public AssetUsagePagedListUseCase(IBaseRepository<Domain.Entities.AssetUsage, AssetUsageDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PagedRequest<Domain.Entities.AssetUsage> request, IOutputPort<PagedResponse<Domain.Entities.AssetUsage>> outputPort)
        {
            var response = await _baseRepository.PagedList(
                request.CompanyId,
                request.PageNumber,
                request.PageSize,
                request.FilterParameters,
                model => model.AssetId == request.ParentId && model.CompanyId == request.CompanyId);

            if (response.Success)
            {
                outputPort.Handle(new PagedResponse<Domain.Entities.AssetUsage>(response.PagedResult, true));
                return true;
            }

            outputPort.Handle(new PagedResponse<Domain.Entities.AssetUsage>(new[] { new Error("", "Model not Found.") }));
            return false;
        }
    }
}
