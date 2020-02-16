using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Part
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
