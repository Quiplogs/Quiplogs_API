﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infrastructure.Data.Entities
{
    public class PartDto : BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public List<ServicePartDto> ServiceParts { get; set; }

        public List<ServiceIntervalPartDto> ServiceIntervalParts { get; set; }
    }
}
