using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class PutPartRequest : IRequest<PutPartResponse>
    {
        public Domain.Entities.Part Part { get; }
        public PutPartRequest(Domain.Entities.Part part)
        {
            Part = part;
        }
    }
}
