using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;

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
            var response = await _baseRepository.PagedList(
                request.CompanyId, 
                request.PageNumber, 
                request.PageSize,
                request.FilterParameters, 
                model => !request.LocationId.HasValue || model.LocationId == request.LocationId.Value,
                model => model.Location);

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
