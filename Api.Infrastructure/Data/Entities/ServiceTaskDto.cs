namespace Api.Infrastructure.Data.Entities
{
    public class ServiceTaskDto : BaseEntity
    {
        public string ServiceId { get; set; }
        public ServiceDto Service { get; set; }
        public string TaskId { get; set; }
        public TaskDto Task { get; set; }
        public string TaskDescription { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}
