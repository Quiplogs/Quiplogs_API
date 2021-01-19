using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Location
{
    public class PutLocationResponse : BaseRepositoryResponse
    {
        public Domain.Entities.Location Location { get; set; }

        public PutLocationResponse(Domain.Entities.Location location, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Location = location;
        }
    }
}
