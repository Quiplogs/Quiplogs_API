using Quiplogs.WorkOrder.Dto.Repositories.PlannedMaintenance;
using System;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Repositories
{
    public interface IPlannedMaintenanceRepository
    {
        Task<ListPlannedMaintenanceResponse> List(Guid companyId, Guid locationId, Guid assetId, int pageNumber, int pageSize, bool? shouldPage);
        Task<int> GetTotalRecords(Guid companyId);
        Task<GetPlannedMaintenanceResponse> Get(Guid id);
        Task<PutPlannedMaintenanceResponse> Put(Domain.Entities.PlannedMaintenanceEntity PlannedMaintenance);
        Task<RemovePlannedMaintenanceResponse> Remove(Guid id);
    }
}
