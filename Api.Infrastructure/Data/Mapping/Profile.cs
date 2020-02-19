using Api.Core.Domain.Entities;
using Api.Infrastructure.Data.Entities;
using AutoMapper;

namespace Api.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<AppUser, UserEntity>().ConstructUsing(u => new UserEntity { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, PasswordHash = u.PasswordHash, Role = u.Role });
            CreateMap<UserEntity, AppUser>().ConstructUsing(au => new AppUser(au.FirstName, au.LastName, au.Email, au.UserName, au.Role, au.Id, au.PasswordHash));
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentDto, Equipment>();
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceDto, Service>();
            CreateMap<TaskEntity, TaskDto>();
            CreateMap<TaskDto, TaskEntity>();
        }
    }
}
