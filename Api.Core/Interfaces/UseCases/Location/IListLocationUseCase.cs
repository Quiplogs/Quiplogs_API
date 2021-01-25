using Quiplogs.Core.Dto.Requests.Location;
using Quiplogs.Core.Dto.Responses.Location;

namespace Quiplogs.Core.Interfaces.UseCases.Location
{
    public interface IListLocationUseCase : IRequestHandler<ListLocationRequest, ListLocationResponse>
    {
    }
}
