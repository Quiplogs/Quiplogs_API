﻿namespace Api.Core.Domain.Entities
{
    public class Part : BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
