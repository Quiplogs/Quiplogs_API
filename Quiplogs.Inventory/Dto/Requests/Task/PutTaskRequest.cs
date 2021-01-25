using Quiplogs.Inventory.Dto.Responses.Task;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Inventory.Dto.Requests.Task
{
    public class PutTaskRequest : IRequest<PutTaskResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CompanyId { get; set; }

        public PutTaskRequest(Guid id, string name, string description, Guid companyId)
        {
            Id = id;
            Name = name;
            Description = description;
            CompanyId = companyId;
        }
    }
}
