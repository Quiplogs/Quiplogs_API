using AutoMapper;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenancePart;
using Quiplogs.WorkOrder.Dto.Requests.PlannedMaintenanceTask;

namespace Quiplogs.WorkOrder.Data.Mapping
{
    public class WorkOrderProfile : Profile
    {
        public WorkOrderProfile()
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
            CreateMap<PutPlannedMaintenancePartDtoRequest, PlannedMaintenancePart>();
            CreateMap<PutPlannedMaintenanceTaskRequest, PlannedMaintenanceTask>();
        }
    }
}
