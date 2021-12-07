using Quiplogs.Core.Dto.Requests.Company;
using Quiplogs.Core.Dto.Responses.Company;

namespace Quiplogs.Core.Interfaces.UseCases
{
    public interface IRegisterCompanyUseCase : IRequestHandler<RegisterCompanyRequest, RegisterCompanyResponse>
    {
    }
}
