using System.Threading.Tasks;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Core.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<CreateCompanyResponse> Put(Company model);

        Task<int> GetTotalRecords();
    }
}
