using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Inventory.Dto.Repositories.Part
{
    public class ListPartResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.Part> Parts { get; set; }

        public ListPartResponse(List<Domain.Entities.Part> parts, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Parts = parts;
        }
    }
}
