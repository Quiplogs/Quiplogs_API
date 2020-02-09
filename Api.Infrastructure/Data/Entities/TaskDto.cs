using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Infrastructure.Data.Entities
{
    public class TaskDto : BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }

        public List<ServiceTaskDto> ServiceTasks { get; set; }

        public List<ServiceIntervalTaskDto> ServiceIntervalTasks { get; set; }
    }
}
