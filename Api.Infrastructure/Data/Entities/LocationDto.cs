﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class LocationDto : BaseEntity
    {
        public int Name { get; set; }

        public long? Lat { get; set; }

        public long? Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity ResponsableUser { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }
    }
}
