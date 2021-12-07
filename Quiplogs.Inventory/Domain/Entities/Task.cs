using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Inventory.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
