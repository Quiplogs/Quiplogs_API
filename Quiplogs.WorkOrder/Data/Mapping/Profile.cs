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

            CreateMap<PlannedMaintenance, PlannedMaintenanceDto>();
            CreateMap<PlannedMaintenanceDto, PlannedMaintenance>();
            CreateMap<PlannedMaintenancePart, PlannedMaintenancePartDto>();
            CreateMap<PlannedMaintenancePartDto, PlannedMaintenancePart>();
            CreateMap<PlannedMaintenanceTask, PlannedMaintenanceTaskDto>();
            CreateMap<PlannedMaintenanceTaskDto, PlannedMaintenanceTask>();

            //CreateMap<Dto.Requests.PlannedMaintenance.PutPlannedMaintenanceRequest, PlannedMaintenance>();
            //CreateMap<PutPlannedMaintenancePartDtoRequest, PlannedMaintenancePart>();
            //CreateMap<PutPlannedMaintenanceTaskRequest, PlannedMaintenanceTask>();
        }
    }
}
