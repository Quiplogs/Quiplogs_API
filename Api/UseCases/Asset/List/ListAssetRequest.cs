using System;

namespace Api.UseCases.Asset.List
{
    public class ListAssetRequest
    {
        public Guid CompanyId { get; set; }
        public Guid? LocationId { get; set; }
        public int PageNumber { get; set; }
    }
}
