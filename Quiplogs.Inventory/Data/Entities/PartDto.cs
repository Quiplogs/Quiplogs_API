using Quiplogs.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.Inventory.Data.Entities
{
    public class PartDto : BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyDto Company { get; set; }
    }
}
