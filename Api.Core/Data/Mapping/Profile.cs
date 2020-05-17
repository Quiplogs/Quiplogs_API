using Api.Core.Domain.Entities;
using AutoMapper;
using Quiplogs.Core.Data.Entities;

namespace Api.Infrastructure.Data.Mapping
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<AppUser, UserEntity>();
            CreateMap<UserEntity, AppUser>();
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
        }
    }
}
