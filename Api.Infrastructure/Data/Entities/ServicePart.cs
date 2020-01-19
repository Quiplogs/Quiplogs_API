using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Infrastructure.Data.Entities
{
    public class ServicePart : BaseEntity
    {
        public string ServiceId { get; set; }
        public ServiceDto Service { get; set; }
        public string PartId { get; set; }
        public PartDto Part { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
