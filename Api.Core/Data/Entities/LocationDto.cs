using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Core.Data.Entities
{
    public class LocationDto : BaseEntityDto
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Lat { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity ResponsibleUser { get; set; }
    }
}
