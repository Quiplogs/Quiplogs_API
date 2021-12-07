using System;

namespace Quiplogs.Dashboard
{
    public class AnalyticsRequest
    {
        public Guid CompanyId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? AssetId { get; set; }

        private string _storedProcedure;
        public string StoredProcedure
        {
            get => _storedProcedure;
            set
            {
                if (StoredProceduresDashboard.Procedures.ContainsKey(value))
                {
                    _storedProcedure = StoredProceduresDashboard.Procedures[value];
                }
            }

        }
    }
}
