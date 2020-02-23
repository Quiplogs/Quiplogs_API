namespace Api.UseCases.Asset.Fetch
{
    public class FetchAssetRequest
    {
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public int PageNumber { get; set; }
    }
}
