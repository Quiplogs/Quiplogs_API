using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Core.Data.Entities
{
    public class BaseLocationDto : BaseEntityDto
    {
        public Guid LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }
    }
}
