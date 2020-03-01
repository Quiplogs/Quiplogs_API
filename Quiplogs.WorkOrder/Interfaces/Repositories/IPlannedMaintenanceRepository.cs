using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenanceRepository
    {
        Task<ListPlannedMaintenanceResponse> List(string companyId, string locationId, string assetId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetPlannedMaintenanceResponse> Get(string id);
        Task<PutPlannedMaintenanceResponse> Put(Domain.Entities.PlannedMaintenanceEntity PlannedMaintenance);
        Task<RemovePlannedMaintenanceResponse> Remove(string id);
    }
}
