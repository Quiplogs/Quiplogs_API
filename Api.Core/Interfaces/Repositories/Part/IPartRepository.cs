﻿using Api.Core.Dto.Repositories.Part;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories
{
    public interface IPartRepository
    {
        Task<ListPartResponse> List(string companyId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetPartResponse> Get(string id);
        Task<PutPartResponse> Put(Domain.Entities.Part Part);
        Task<RemovePartResponse> Remove(string id);
    }
}
