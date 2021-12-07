using Quiplogs.Core.Data.Entities;

namespace Quiplogs.Inventory.Data.Entities
{
    public class TaskDto : BaseEntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
