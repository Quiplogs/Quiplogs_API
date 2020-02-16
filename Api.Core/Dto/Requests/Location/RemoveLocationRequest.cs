using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Location
{
    public class RemoveLocationRequest : IRequest<RemoveLocationResponse>
    {
        public string Id { get; }
        public RemoveLocationRequest(string id)
        {
            Id = id;
        }
    }
}
