using Api.Core.Dto.Requests.Location;
using Api.Core.Dto.Responses.Location;

namespace Api.Core.Interfaces.UseCases.Location
{
    public interface IListLocationUseCase : IRequestHandler<ListLocationRequest, ListLocationResponse>
    {
    }
}
