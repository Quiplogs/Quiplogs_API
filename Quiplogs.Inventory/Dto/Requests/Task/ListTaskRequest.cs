using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;
using System;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class ListTaskRequest : IRequest<ListTaskResponse>
    {
        public Guid CompanyId { get; }
        public int PageNumber { get; }
        public string FilterName { get; set; }
        public ListTaskRequest(Guid companyId, int pageNumber, string filterName)
        {
            CompanyId = companyId;
            PageNumber = pageNumber;
            FilterName = filterName;
        }
    }
}
