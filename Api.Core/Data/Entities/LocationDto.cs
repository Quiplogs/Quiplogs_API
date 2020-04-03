﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Core.Data.Entities
{
    public class LocationDto : BaseEntity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Lat { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Long { get; set; }

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
