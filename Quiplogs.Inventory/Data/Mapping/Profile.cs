using AutoMapper;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.Inventory.Domain.Entities;

namespace Quiplogs.Inventory.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<TaskEntity, TaskDto>();
            CreateMap<TaskDto, TaskEntity>();

            CreateMap<Part, PartDto>();
            CreateMap<PartDto, Part>();
        }
    }
}
