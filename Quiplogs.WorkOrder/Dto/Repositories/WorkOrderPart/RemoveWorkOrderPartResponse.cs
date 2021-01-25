using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrderPart
{
    public class RemoveWorkOrderPartResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemoveWorkOrderPartResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}

