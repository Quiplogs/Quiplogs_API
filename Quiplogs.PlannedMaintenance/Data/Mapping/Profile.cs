using AutoMapper;
using Quiplogs.PlannedMaintenance.Data.Entities;
using Quiplogs.PlannedMaintenance.Domain.Entities;

namespace Quiplogs.PlannedMaintenance.Data.Mapping
{
    public class PlannedMaintenanceProfile : Profile
    {
        public PlannedMaintenanceProfile()
        {
            CreateMap<Domain.Entities.PlannedMaintenance, PlannedMaintenanceDto>();
            CreateMap<PlannedMaintenanceDto, Domain.Entities.PlannedMaintenance>();
            CreateMap<PlannedMaintenancePart, PlannedMaintenancePartDto>();
            CreateMap<PlannedMaintenancePartDto, PlannedMaintenancePart>();
            CreateMap<PlannedMaintenanceTask, PlannedMaintenanceTaskDto>();
            CreateMap<PlannedMaintenanceTaskDto, PlannedMaintenanceTask>();
        }
    }
}
