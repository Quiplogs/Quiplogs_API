using Api.Core.Domain.Entities;

namespace Quiplogs.Inventory.Domain.Entities
{
    public class Part : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        public string LocationId { get; set; }

        public string ImgFileName { get; set; }

        public string ImgUrl { get; set; }        
    }
}
