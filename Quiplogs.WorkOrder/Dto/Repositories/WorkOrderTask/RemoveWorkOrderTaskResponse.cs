using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

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

