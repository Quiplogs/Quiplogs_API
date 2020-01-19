using Api.Core.Domain.Entities;
using Api.Core.Dto.Repositories;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories
{
    public interface IEquipmentRepository
    {
        Task<PagedResultsResponse<Equipment>> GetPagedResults(int pageNumber);
    }
}
