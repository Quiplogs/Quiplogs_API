using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Location
{
    public class GetLocationResponse : BaseRepositoryResponse
    {
        public Domain.Entities.Location Location { get; set; }

        public GetLocationResponse(Domain.Entities.Location location, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Location = location;
        }
    }
}
