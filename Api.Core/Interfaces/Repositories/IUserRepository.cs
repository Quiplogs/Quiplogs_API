using Api.Core.Domain.Entities;
using Api.Core.Dto.Repositories.User;
using System;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(AppUser user, string password);
        Task<AppUser> FindByName(string userName);
        Task<bool> CheckPassword(AppUser user, string password);
        Task<GetAllUsersResponse> GetAll(Guid companyId, Guid locationId);
        Task<GetUserResponse> Get(Guid id);
        Task<UpdateUserResponse> Update(AppUser user);
        Task<RemoveUserResponse> Remove(Guid id);
    }
}
