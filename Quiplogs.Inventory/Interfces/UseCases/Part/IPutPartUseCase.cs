using Quiplogs.Core.Interfaces;
using Quiplogs.Inventory.Dto.Requests.Part;
using Quiplogs.Inventory.Dto.Responses.Part;

namespace Quiplogs.Inventory.Interfces.UseCases.Part
{
    public interface IPutPartUseCase : IRequestHandler<PutPartRequest, PutPartResponse>
    {
    }
}
