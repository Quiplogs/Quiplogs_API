using Api.Core.Domain.Entities;
using System;

namespace Quiplogs.Inventory.Domain.Entities
{
    public class Part : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CompanyId { get; set; }

        public Guid LocationId { get; set; }

        public string ImgFileName { get; set; }

        public string ImgUrl { get; set; }        
    }
}
