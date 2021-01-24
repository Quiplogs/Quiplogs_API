using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Repositories.Part
{
    public class GetPartResponse : BaseRepositoryResponse
    {
        public Domain.Entities.Part Part { get; set; }

        public GetPartResponse(Domain.Entities.Part part, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Part = part;
        }
    }
}
