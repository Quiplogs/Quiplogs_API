﻿using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.PlannedMaintenance.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quiplogs.PlannedMaintenance.UseCases.PlannedMaintenance
{
    public class PlannedMaintenancePagedListUseCase : IPagedListUseCase<Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto>
    {
        private readonly IBaseRepository<Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> _baseRepository;

        public PlannedMaintenancePagedListUseCase(IBaseRepository<Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Handle(PagedRequest<Domain.Entities.PlannedMaintenance> request, IOutputPort<PagedResponse<Domain.Entities.PlannedMaintenance>> outputPort)
        {
            var response = await _baseRepository.PagedList(
                request.CompanyId,
                request.PageNumber,
                request.PageSize,
                request.FilterParameters,
                model => (!request.LocationId.HasValue || model.LocationId == request.LocationId.Value) && model.AssetId == request.ParentId
                    && model.CompanyId == request.CompanyId,
                including: source => source
                .Include(model => model.PlannedMaintenanceParts)
                .Include(model => model.PlannedMaintenanceTasks)
                .Include(model => model.Asset));

            if (response.Success)
            {
                outputPort.Handle(new PagedResponse<Domain.Entities.PlannedMaintenance>(response.PagedResult, true));
                return true;
            }

            outputPort.Handle(new PagedResponse<Domain.Entities.PlannedMaintenance>(response.Errors));
            return false;
        }
    }
}
