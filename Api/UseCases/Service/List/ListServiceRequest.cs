namespace Api.UseCases.Service.List
{
    public class ListServiceRequest
    {
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public int PageNumber { get; set; }
    }
}
