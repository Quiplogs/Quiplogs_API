using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Part
{
    public class GetPartRequest : IRequest<GetPartResponse>
    {
        public string Id { get; }
        public GetPartRequest(string id)
        {
            Id = id;
        }
    }
}
