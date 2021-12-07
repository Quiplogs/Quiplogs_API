using AutoMapper;
using Quiplogs.WorkOrder.Data.Entities;
using Quiplogs.WorkOrder.Domain.Entities;

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
        }
    }
}
