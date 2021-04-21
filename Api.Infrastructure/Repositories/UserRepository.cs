using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories.User;
using Quiplogs.Core.Helpers;
using Quiplogs.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiplogs.Infrastructure.SqlContext;

namespace Quiplogs.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICaching _cache;

        public UserRepository(UserManager<UserEntity> userManager, SqlDbContext context, IMapper mapper, ICaching cache)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cache = cache;
            _context = context;
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

        public async Task<GetAllUsersResponse> GetAll(Guid companyId, Guid? locationId)
        {
            var users = await _userManager.Users
                .Where(x => x.CompanyId == companyId
                            && (!locationId.HasValue || x.LocationId == locationId.Value))
                .ToListAsync();

            List<AppUser> mappedUsers = _mapper.Map<List<AppUser>>(users);
            return new GetAllUsersResponse(mappedUsers, true, null);
        }

        public async Task<PagedUserResponse> GetPagedList(Guid companyId, int pageNumber, int pageSize, Guid? locationId)
        {
            var userList = await _userManager.Users
                .Where(x => x.CompanyId == companyId
                            && (!locationId.HasValue || x.LocationId == locationId.Value))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<AppUser> mappedList = _mapper.Map<List<AppUser>>(userList);
            var total = await GetTotalRecords(companyId);
            var pagedResult = new PagedResult<AppUser>(mappedList, total, pageNumber, pageSize);

            return new PagedUserResponse(pagedResult, true, null);
        }

        public async Task<GetAllUsersResponse> GetAllTechnicians(Guid companyId, Guid? locationId)
        {
            var users = await _userManager.Users
                .Where(x =>
                    x.CompanyId == companyId
                    && x.Role == Role.Technician
                    && (string.IsNullOrEmpty(locationId.ToString()) || x.LocationId == locationId))
                .ToListAsync();

            List<AppUser> mappedUsers = _mapper.Map<List<AppUser>>(users);
            return new GetAllUsersResponse(mappedUsers, true, null);
        }

        public async Task<GetUserResponse> Get(Guid id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            AppUser mappedUser = _mapper.Map<AppUser>(user);
            return new GetUserResponse(mappedUser, true, null);
        }

        public async Task<UpdateUserResponse> Update(AppUser user)
        {
            var currentUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == user.Id);

            var appUser = _mapper.Map<UserEntity>(user);

            _context.Entry(currentUser).State = EntityState.Modified;
            appUser.SecurityStamp = Guid.NewGuid().ToString();
            appUser.ConcurrencyStamp = currentUser.ConcurrencyStamp;

            //Update Password
            if (!string.IsNullOrWhiteSpace(user.CurrentPassword) && !string.IsNullOrWhiteSpace(user.Password))
            {
                if (user.Password.Equals(user.ReenteredPassword))
                {
                    var updateResult = await _userManager.ChangePasswordAsync(currentUser, user.CurrentPassword, user.Password);
                    if (!updateResult.Succeeded)
                    {
                        return new UpdateUserResponse(user, updateResult.Succeeded, updateResult.Succeeded ? null : updateResult.Errors.Select(e => new Error(e.Code, e.Description)));
                    }
                }
            }

            var identityResult = await _userManager.UpdateAsync(appUser);
            AppUser mappedUser = _mapper.Map<AppUser>(appUser);
            return new UpdateUserResponse(mappedUser, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<RemoveUserResponse> Remove(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var identityResult = await _userManager.DeleteAsync(user);
            AppUser mappedUser = _mapper.Map<AppUser>(user);
            return new RemoveUserResponse($"{user.FirstName} {user.LastName}", identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        private async Task<int> GetTotalRecords(Guid companyId)
        {
            var cacheKey = $"Users-total-{companyId}";
            var cachedTotal = await _cache.GetAsnyc<int>(cacheKey);

            if (cachedTotal == 0)
            {
                await UpdateTotalItems(companyId);
            }

            return cachedTotal;
        }

        private async Task UpdateTotalItems(Guid companyId)
        {
            var cacheKey = $"Users-total-{companyId}";
            var cachedTotal = _userManager.Users.Where(x => x.CompanyId == companyId).Count();
            await _cache.SetAsnyc(cacheKey, cachedTotal);
        }
    }
}
