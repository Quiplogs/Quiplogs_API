namespace Api.Infrastructure.Data.Entities
{
    public class ServiceIntervalPart : BaseEntity
    {
        public string ServiceIntervalId { get; set; }
        public ServiceIntervalDto ServiceInterval { get; set; }
        public string PartId { get; set; }
        public PartDto Part { get; set; }
    }
}
