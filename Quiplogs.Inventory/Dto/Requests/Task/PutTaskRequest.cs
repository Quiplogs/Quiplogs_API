using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Task;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class PutTaskRequest : IRequest<PutTaskResponse>
    {
        public string Id { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        public PutTaskRequest(string id, string code, string description, string companyId)
        {
            Id = id;
            Code = code;
            Description = description;
            CompanyId = companyId;
        }
    }
}
