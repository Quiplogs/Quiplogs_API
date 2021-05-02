using Quiplogs.Core.Data.Entities;

namespace Quiplogs.Inventory.Data.Entities
{
    public class PartDto : BaseEntityDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
