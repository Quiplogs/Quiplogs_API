using Api.Core.Dto.Repositories.Service;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories
{
    public interface IServiceRepository
    {
        Task<ListServiceResponse> List(string companyId, string locationId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetServiceResponse> Get(string id);
        Task<PutServiceResponse> Put(Domain.Entities.Service Service);
        Task<RemoveServiceResponse> Remove(string id);
    }
}
