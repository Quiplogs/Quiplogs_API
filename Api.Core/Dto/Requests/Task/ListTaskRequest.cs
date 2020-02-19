using Api.Core.Dto.Responses.Task;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Task
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
