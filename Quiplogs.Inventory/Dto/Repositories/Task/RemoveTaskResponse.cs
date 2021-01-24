using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Repositories.Task
{
    public class RemoveTaskResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemoveTaskResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
