using Api.Core.Domain.Entities;
using AutoMapper;
using Quiplogs.Core.Data.Entities;

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
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
        }
    }
}
