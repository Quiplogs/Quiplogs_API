using Api.Core.Domain.Entities;

namespace Quiplogs.Assets.Domain.Entities
{
    public class Asset : BaseEntity
    {
        public string Code { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int BuildYear { get; set; }

        public decimal CurrentWorkDone { get; set; }

        public string UoM { get; set; }

        public decimal WorkDoneToday { get; set; }

        public string ImgUrl { get; set; }

        public string LocationId { get; set; }

        //public LocationDto Location { get; set; }

        public string CompanyId { get; set; }

        //public CompanyDto Company { get; set; }

        //public List<PlannedMaintenanceDto> WorkOrdersIntervals { get; set; }

        //public List<WorkOrderDto> WorkOrders { get; set; }
    }
}
