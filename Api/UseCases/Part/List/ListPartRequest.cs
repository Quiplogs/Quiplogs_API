namespace Api.UseCases.Part.List
{
    public class ListPartRequest
    {
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public int PageNumber { get; set; }
        public string FilterName { get; set; }
    }
}
