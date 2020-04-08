namespace Api.UseCases.Task.List
{
    public class ListTaskRequest
    {
        public string CompanyId { get; set; }
        public int PageNumber { get; set; }
        public string FilterName { get; set; }
    }
}
