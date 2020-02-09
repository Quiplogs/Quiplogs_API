namespace Api.Infrastructure.Data.Entities
{
    public class ServicePartDto : BaseEntity
    {
        public string ServiceId { get; set; }
        public ServiceDto Service { get; set; }
        public string PartId { get; set; }
        public PartDto Part { get; set; }
        public string PartCode { get; set; }
        public string PartDescription { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public bool IsCompleted { get; set; }
    }
}
