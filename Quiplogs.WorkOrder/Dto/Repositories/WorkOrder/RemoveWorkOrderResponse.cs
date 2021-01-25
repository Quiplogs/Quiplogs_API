using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrder
{
    public class RemoveWorkOrderResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemoveWorkOrderResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
