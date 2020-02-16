using Api.Core.Dto.Requests.Part;
using Api.Core.Dto.Responses.Part;

namespace Api.Core.Interfaces.UseCases.Part
{
    public interface IRemovePartUseCase : IRequestHandler<RemovePartRequest, RemovePartResponse>
    {
    }
}
