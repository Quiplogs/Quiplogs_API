using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Location
{
    public class ListLocationResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.Location> Locations { get; set; }

        public ListLocationResponse(List<Domain.Entities.Location> locations, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Locations = locations;
        }
    }
}
