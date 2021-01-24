using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using System;

namespace Api.Core.Dto.Requests.Location
{
    public class GetLocationRequest : IRequest<GetLocationResponse>
    {
        public Guid Id { get; }
        public GetLocationRequest(Guid id)
        {
            Id = id;
        }
    }
}
