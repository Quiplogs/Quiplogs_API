using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Location
{
    public class PutLocationRequest : IRequest<PutLocationResponse>
    {
        public string Name { get; set; }

        public long? Lat { get; set; }

        public long? Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string UserId { get; set; }

        public string CompanyId { get; set; }

        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }

        public PutLocationRequest(string name, string city, string country, string userId, string companyId, string imageFileName, string imageBase64, string imageMimeType, long? lat, long? longitude)
        {
            Name = name;
            Lat = lat;
            Long = longitude;
            City = city;
            Country = country;
            UserId = userId;
            CompanyId = companyId;
            ImageFileName = imageFileName;
            ImageBase64 = imageBase64;
            ImageMimeType = imageMimeType; 
        }
    }
}
