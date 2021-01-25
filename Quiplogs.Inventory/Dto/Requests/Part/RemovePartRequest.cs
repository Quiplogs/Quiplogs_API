using Quiplogs.Inventory.Dto.Responses.Part;
using System;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class RemovePartRequest : IRequest<RemovePartResponse>
    {
        public Guid Id { get; }
        public RemovePartRequest(Guid id)
        {
            Id = id;
        }
    }
}
