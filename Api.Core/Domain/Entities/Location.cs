using System;

namespace Quiplogs.Core.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        
        public decimal? Lat { get; set; }
        
        public decimal? Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public Guid? UserId { get; set; }

        public string ImageFileName { get; set; }

        public string ImageUrl { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }
    }
}
