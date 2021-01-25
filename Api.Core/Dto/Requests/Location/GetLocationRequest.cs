using System;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Location
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
