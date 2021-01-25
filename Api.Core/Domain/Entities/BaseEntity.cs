using System;

namespace Quiplogs.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
