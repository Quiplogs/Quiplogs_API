using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrderTask
{
    public class RemoveWorkOrderTaskResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemoveWorkOrderTaskResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}

