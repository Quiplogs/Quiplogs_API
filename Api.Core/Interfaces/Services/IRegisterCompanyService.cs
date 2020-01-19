using Api.Core.Dto.Requests.Company;
using Api.Core.Dto.Responses.Company;

namespace Api.Core.Interfaces.Services
{
    public interface IRegisterCompanyService : IRequestHandler<RegisterCompanyRequest, RegisterCompanyResponse>
    {
    }
}
