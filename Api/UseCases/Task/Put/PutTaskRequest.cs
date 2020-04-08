namespace Api.UseCases.Task.Put
{
    public class PutTaskRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }
    }
}
