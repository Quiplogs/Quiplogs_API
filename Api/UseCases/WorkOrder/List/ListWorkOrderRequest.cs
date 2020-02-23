namespace Api.UseCases.WorkOrder.List
{
    public class ListWorkOrderRequest
    {
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public int PageNumber { get; set; }
    }
}
