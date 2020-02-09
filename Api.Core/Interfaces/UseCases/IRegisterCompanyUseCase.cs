using Api.Core.Dto.Requests.Company;
using Api.Core.Dto.Responses.Company;

namespace Api.Core.Interfaces.UseCases
{
    public interface IRegisterCompanyUseCase : IRequestHandler<RegisterCompanyRequest, RegisterCompanyResponse>
    {
    }
}
