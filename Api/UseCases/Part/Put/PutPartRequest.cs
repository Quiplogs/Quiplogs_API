namespace Api.UseCases.Part.Put
{
    public class PutPartRequest
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        public string LocationId { get; set; }

        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }
    }
}
