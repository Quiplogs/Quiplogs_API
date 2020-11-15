using System;

namespace Api.Dashboard.Main
{
    public class DashboardMainRequest
    {
        public Guid CompanyId { get; set; }

        public Guid? LocationId { get; set; }

        public string QueryName { get; set; }
    }
}
