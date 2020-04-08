using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class ListTaskRequest : IRequest<ListTaskResponse>
    {
        public string CompanyId { get; }
        public int PageNumber { get; }
        public string FilterName { get; set; }
        public ListTaskRequest(string companyId, int pageNumber, string filterName)
        {
            CompanyId = companyId;
            PageNumber = pageNumber;
            FilterName = filterName;
        }
    }
}
