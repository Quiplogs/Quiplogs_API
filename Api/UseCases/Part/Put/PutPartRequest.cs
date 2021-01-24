using System;

namespace Api.UseCases.Part.Put
{
    public class PutPartRequest
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CompanyId { get; set; }

        public Guid LocationId { get; set; }

        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }
    }
}
