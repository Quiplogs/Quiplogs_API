using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;
using System;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class PutPartRequest : IRequest<PutPartResponse>
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

        public PutPartRequest(Guid id, string code, string name, string description, Guid companyId, Guid locationId, string imageFileName, string imageBase64, string imageMimeType)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            CompanyId = companyId;
            LocationId = locationId;
            ImageFileName = imageFileName;
            ImageBase64 = imageBase64;
            ImageMimeType = imageMimeType;
        }
    }
}
