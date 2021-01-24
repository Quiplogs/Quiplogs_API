using Api.Core.Dto;
using Api.Core.Dto.Repositories;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.WorkOrder.Dto.Repositories.WorkOrderPart
{
    public class ListWorkOrderPartResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.WorkOrderPart> WorkOrderParts { get; set; }

        public ListWorkOrderPartResponse(List<Domain.Entities.WorkOrderPart> workOrderParts, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            WorkOrderParts = workOrderParts;
        }
    }
}
