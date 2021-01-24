using System;

namespace Api.UseCases.Task.Put
{
    public class PutTaskRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CompanyId { get; set; }
    }
}
