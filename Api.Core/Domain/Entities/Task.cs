namespace Api.Core.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        //public List<ServiceTaskDto> ServiceTasks { get; set; }

        //public List<ServiceIntervalTaskDto> ServiceIntervalTasks { get; set; }
    }
}
