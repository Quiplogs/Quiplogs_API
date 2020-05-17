using Api.Core.Domain.Entities;
using Api.Core.Dto.Repositories;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<CreateCompanyResponse> Put(Company model);

        Task<int> GetTotalRecords();
    }
}
