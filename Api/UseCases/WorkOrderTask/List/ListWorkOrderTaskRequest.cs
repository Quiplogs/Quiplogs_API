using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderTask.List
{
    public class ListWorkOrderTaskRequest
    {
        public Guid WordOrderId { get; set; }
        public Guid CompanyId { get; set; }
        public int PageNumber { get; set; }
    }
}
