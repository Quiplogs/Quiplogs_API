using System;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.Location
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
