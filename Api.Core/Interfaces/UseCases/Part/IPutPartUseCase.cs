using Api.Core.Dto.Requests.Part;
using Api.Core.Dto.Responses.Part;

namespace Api.Core.Interfaces.UseCases.Part
{
    public interface IPutPartUseCase : IRequestHandler<PutPartRequest, PutPartResponse>
    {
    }
}
