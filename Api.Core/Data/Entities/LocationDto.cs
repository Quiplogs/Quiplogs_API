using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Core.Data.Entities
{
    public class LocationDto : BaseEntity
    {
        public string Name { get; set; }

        public long? Lat { get; set; }

        public long? Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string UserId { get; set; }

        public string ImgFileName { get; set; }

        public string ImgUrl { get; set; }

        [ForeignKey("UserId")]
        public UserEntity ResponsableUser { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }
    }
}
