﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Repositories.User;

namespace Quiplogs.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(AppUser user, string password);
        Task<AppUser> FindByName(string userName);
        Task<bool> CheckPassword(Guid id, string password);
        Task<GetAllUsersResponse> GetAll(Guid companyId, Guid? locationId);
        Task<PagedUserResponse> GetPagedList(Guid companyId, int pageNumber, int pageSize, Dictionary<string, string> filterParameters, Guid? locationId);
        Task<GetAllUsersResponse> GetAllTechnicians(Guid companyId, Guid? locationId);
        Task<GetUserResponse> Get(Guid id);
        Task<UpdateUserResponse> Update(AppUser user);
        Task<RemoveUserResponse> Remove(Guid id);
    }
}
