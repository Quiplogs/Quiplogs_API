using System;
using System.Collections.Generic;
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

        public List<ServicePart> ServiceParts { get; set; }

        public List<ServiceIntervalPart> ServiceIntervalParts { get; set; }
    }
}
