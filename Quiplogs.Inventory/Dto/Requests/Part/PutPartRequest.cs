using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class PutPartRequest : IRequest<PutPartResponse>
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

        public PutPartRequest(string id, string code, string name, string description, string companyId, string locationId, string imageFileName, string imageBase64, string imageMimeType)
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
