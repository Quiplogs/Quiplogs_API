

namespace Api.Infrastructure.Data.Entities
{
    public class ServiceIntervalTaskDto : BaseEntity
    {
        public string ServiceIntervalId { get; set; }
        public ServiceIntervalDto ServiceInterval { get; set; }
        public string TaskId { get; set; }
        public TaskDto Task { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
    }
}
