using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UseCases.WorkOrderPart.List
{
    public class ListWorkOrderPartRequest
    {
        public string WordOrderId { get; set; }
        public int PageNumber { get; set; }
    }
}
