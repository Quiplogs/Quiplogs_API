using Quiplogs.Inventory.Dto.Responses.Part;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class GetPartRequest : IRequest<GetPartResponse>
    {
        public Guid Id { get; }
        public GetPartRequest(Guid id)
        {
            Id = id;
        }
    }
}
