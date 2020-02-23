using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class ListTaskRequest : IRequest<ListTaskResponse>
    {
        public string CompanyId { get; }
        public int PageNumber { get; }
        public ListTaskRequest(string companyId, int pageNumber)
        {
            CompanyId = companyId;
            PageNumber = pageNumber;
        }
    }
}
