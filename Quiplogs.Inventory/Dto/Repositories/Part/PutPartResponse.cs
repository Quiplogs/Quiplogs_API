using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;
namespace Quiplogs.Inventory.Dto.Repositories.Part
{
    public class PutPartResponse : BaseRepositoryResponse
    {
        public Domain.Entities.Part Part { get; set; }

        public PutPartResponse(Domain.Entities.Part part, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Part = part;
        }
    }
}
