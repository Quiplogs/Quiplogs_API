using System;
using Quiplogs.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Inventory.Data.Entities
{
    public class PartDto : BaseEntityDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgFileName { get; set; }

        public string ImgUrl { get; set; }

        public Guid LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }
    }
}
