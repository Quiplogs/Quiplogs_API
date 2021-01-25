using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiplogs.Core.Data.Entities
{
    public class BaseLocationDto : BaseEntityDto
    {
        public Guid LocationId { get; set; }

        [ForeignKey("LocationId")]
        public LocationDto Location { get; set; }
    }
}
