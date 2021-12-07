using System;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Inventory.Domain.Entities
{
    public class Part : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }
    }
}
