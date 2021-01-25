using System;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Location
{
    public class PutLocationRequest : IRequest<PutLocationResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public Guid UserId { get; set; }

        public Guid CompanyId { get; set; }

        public string ImageFileName { get; set; }

        public string ImageBase64 { get; set; }

        public string ImageMimeType { get; set; }

        public PutLocationRequest(Guid id, string name, string city, string country, Guid userId, Guid companyId, string imageFileName, string imageBase64, string imageMimeType, string lat, string longitude)
        {
            Id = id;
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
