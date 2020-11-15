using System;

namespace Quiplogs.Dashboard
{
    public class AnalyticsRequest
    {
        public Guid CompanyId { get; set; }

        public Guid? LocationId { get; set; }

        private string storedProcedure;
        public string StoredProcedure
        {
            get => storedProcedure;
            set
            {
                if (StoredProceduresDashboard.Procedures.ContainsKey(value))
                {
                    storedProcedure = StoredProceduresDashboard.Procedures[value];
                }
            }

        }
    }
}
