using Api.Core.Dto.Repositories.Location;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories.Location
{
    public interface ILocationRepository
    {
        Task<ListLocationResponse> List(string companyId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetLocationResponse> Get(string id);
        Task<PutLocationResponse> Put(Domain.Entities.Location Location);
        Task<RemoveLocationResponse> Remove(string id);
    }
}
