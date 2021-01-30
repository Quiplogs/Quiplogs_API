using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories.User;
using Quiplogs.Core.Interfaces.Repositories;

namespace Quiplogs.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private List<Error> _errors;

        public UserRepository(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _errors = new List<Error>();
        }

        public async Task<CreateUserResponse> Create(AppUser user, string password)
        {
            var appUser = _mapper.Map<UserEntity>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            return new CreateUserResponse(appUser.Id, identityResult.Succeeded,
                identityResult.Succeeded
                    ? null
                    : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<AppUser> FindByName(string userName)
        {
            return _mapper.Map<AppUser>(await _userManager.FindByEmailAsync(userName));
        }

        public async Task<bool> CheckPassword(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<UserEntity>(user), password);
        }

        public async Task<GetAllUsersResponse> GetAll(Guid companyId, Guid locationId)
        {
            var users = await _userManager.Users
                                                .Where(x =>x.CompanyId == companyId
                                                && (string.IsNullOrEmpty(locationId.ToString()) || x.LocationId == locationId))
                                                .ToListAsync();

            List<AppUser> mappedUsers = _mapper.Map<List<AppUser>>(users);
            return new GetAllUsersResponse(mappedUsers, true, null);
        }

        public async Task<GetUserResponse> Get(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            AppUser mappedUser = _mapper.Map<AppUser>(user);
            return new GetUserResponse(mappedUser, true, null);
        }

        public async Task<UpdateUserResponse> Update(AppUser user)
        {
            var appUser = _mapper.Map<UserEntity>(user);
            var identityResult = await _userManager.UpdateAsync(appUser);
            AppUser mappedUser = _mapper.Map<AppUser>(user);
            return new UpdateUserResponse(mappedUser, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<RemoveUserResponse> Remove(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var identityResult = await _userManager.DeleteAsync(user);
            AppUser mappedUser = _mapper.Map<AppUser>(user);
            return new RemoveUserResponse($"{user.FirstName} {user.LastName}", identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }
    }
}
