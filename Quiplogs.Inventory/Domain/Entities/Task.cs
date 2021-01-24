using Api.Core.Domain.Entities;
using System;

namespace Quiplogs.Inventory.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
