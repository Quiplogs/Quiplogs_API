using Api.Core.Dto.Repositories.Equipment;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories.Equipment
{
    public interface IEquipmentRepository
    {
        Task<FetchEquipmentResponse> GetAll(string companyId, string locationId, int pageNumber, int pageSize);
        Task<int> GetTotalRecords(string companyId);
        Task<GetEquipmentResponse> Get(string id);
        Task<UpdateEquipmentResponse> Put(Domain.Entities.Equipment equipment);
        Task<RemoveEquipmentResponse> Remove(string id);
    }
}
