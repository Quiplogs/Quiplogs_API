using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Repositories.Part
{
    public class RemovePartResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemovePartResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
