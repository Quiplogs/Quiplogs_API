namespace Api.Core.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }

        public long? Lat { get; set; }

        public long? Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string UserId { get; set; }

        public string ImgFileName { get; set; }

        public string ImgUrl { get; set; }
        
        public string CompanyId { get; set; }
    }
}
