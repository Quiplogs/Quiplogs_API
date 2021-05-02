using AutoMapper;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Data.Mapping
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
            CreateMap<Blob, BlobEntity>();
            CreateMap<BlobEntity, Blob>();
        }
    }
}
