using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;
using System;

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
