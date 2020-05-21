using AutoMapper;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;

namespace Quiplogs.WorkOrder.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<WorkOrderEntity, WorkOrderDto>();
            CreateMap<WorkOrderDto, WorkOrderEntity>();
            CreateMap<WorkOrderPart, WorkOrderPartDto>();
            CreateMap<WorkOrderPartDto, WorkOrderPart>();
            CreateMap<WorkOrderTask, WorkOrderTaskDto>();
            CreateMap<WorkOrderTaskDto, WorkOrderTask>();

            CreateMap<PlannedMaintenanceEntity, PlannedMaintenanceDto>();
            CreateMap<PlannedMaintenanceDto, PlannedMaintenanceEntity>();
            CreateMap<PlannedMaintenancePart, PlannedMaintenancePartDto>();
            CreateMap<PlannedMaintenancePartDto, PlannedMaintenancePart>();
            CreateMap<PlannedMaintenanceTask, PlannedMaintenanceTaskDto>();
            CreateMap<PlannedMaintenanceTaskDto, PlannedMaintenanceTask>();

            CreateMap<Dto.Requests.PlannedMaintenance.PutPlannedMaintenanceRequest, PlannedMaintenanceEntity>();
        }
    }
}
