using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using System;

namespace Api.Core.Dto.Requests.Location
{
    public class RemoveLocationRequest : IRequest<RemoveLocationResponse>
    {
        public Guid Id { get; }
        public RemoveLocationRequest(Guid id)
        {
            Id = id;
        }
    }
}
