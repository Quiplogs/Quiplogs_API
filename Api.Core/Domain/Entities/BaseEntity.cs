using System;

namespace Api.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
