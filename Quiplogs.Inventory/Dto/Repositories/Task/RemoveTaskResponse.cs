using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

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
