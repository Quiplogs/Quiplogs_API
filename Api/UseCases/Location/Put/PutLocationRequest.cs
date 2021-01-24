using System;

namespace Api.UseCases.Location.Put
{
    public class PutLocationRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public object Lat { get; set; }

        public object Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }

        public Guid UserId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
