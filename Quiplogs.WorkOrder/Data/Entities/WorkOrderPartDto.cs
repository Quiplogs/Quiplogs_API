using Quiplogs.Core.Data.Entities;
using Quiplogs.Inventory.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiplogs.WorkOrder.Data.Entities
{
    public class WorkOrderPartDto : BaseEntity
    {
        public string WorkOrderId { get; set; }
        public WorkOrderDto WorkOrder { get; set; }
        public string PartId { get; set; }
        public PartDto Part { get; set; }
        public string PartCode { get; set; }
        public string PartDescription { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Quantity { get; set; }
        public int UoM { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
