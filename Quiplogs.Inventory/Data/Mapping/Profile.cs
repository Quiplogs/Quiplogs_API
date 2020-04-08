using AutoMapper;
using Quiplogs.Inventory.Data.Entities;
using Quiplogs.Inventory.Domain.Entities;

namespace Quiplogs.Inventory.Data.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<TaskEntity, TaskDto>();
            CreateMap<TaskDto, TaskEntity>();
            CreateMap<Part, PartDto>();
            CreateMap<PartDto, Part>();
        }
    }
}
