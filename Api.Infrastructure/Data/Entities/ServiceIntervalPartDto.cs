namespace Api.Infrastructure.Data.Entities
{
    public class ServiceIntervalPartDto : BaseEntity
    {
        public string ServiceIntervalId { get; set; }
        public ServiceIntervalDto ServiceInterval { get; set; }
        public string PartId { get; set; }
        public PartDto Part { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
    }
}
