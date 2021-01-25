using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
