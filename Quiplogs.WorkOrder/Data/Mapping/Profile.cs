using AutoMapper;
using Quiplogs.Infrastructure.Data.Entities;

namespace Quiplogs.WorkOrder.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Domain.Entities.WorkOrder, WorkOrderDto>();
            CreateMap<WorkOrderDto, Domain.Entities.WorkOrder>();
        }
    }
}
