using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Location
{
    public class ListLocationResponse : BaseResponse
    {
        public List<Domain.Entities.Location> Locations { get; set; }

        public ListLocationResponse(List<Domain.Entities.Location> locations, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Locations = locations;
        }
    }
}
