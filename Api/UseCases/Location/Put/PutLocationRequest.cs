namespace Api.UseCases.Location.Put
{
    public class PutLocationRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public object Lat { get; set; }

        public object Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }

        public string UserId { get; set; }

        public string CompanyId { get; set; }
    }
}
