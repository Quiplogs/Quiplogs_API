using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Location
{
    public class PutLocationRequest : IRequest<PutLocationResponse>
    {
        public Domain.Entities.Location Location { get; }
        public PutLocationRequest(Domain.Entities.Location location)
        {
            Location = location;
        }
    }
}
