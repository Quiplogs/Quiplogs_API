using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Location
{
    public class GetLocationRequest : IRequest<GetLocationResponse>
    {
        public string Id { get; }
        public GetLocationRequest(string id)
        {
            Id = id;
        }
    }
}
