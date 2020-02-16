using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Part
{
    public class RemovePartRequest : IRequest<RemovePartResponse>
    {
        public string Id { get; }
        public RemovePartRequest(string id)
        {
            Id = id;
        }
    }
}
