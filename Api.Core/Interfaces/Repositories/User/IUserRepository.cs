using Api.Core.Domain.Entities;
using Api.Core.Dto.Repositories.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories.User
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(AppUser user, string password);
        Task<AppUser> FindByName(string userName);
        Task<bool> CheckPassword(AppUser user, string password);
        Task<GetAllUsersResponse> GetAll(string companyId, string locationId);
        Task<GetUserResponse> Get(string id);
        Task<UpdateUserResponse> Update(AppUser user);
        Task<RemoveUserResponse> Remove(string id);
    }
}
