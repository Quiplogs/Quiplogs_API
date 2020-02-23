using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class RemovePartRequest : IRequest<RemovePartResponse>
    {
        public string Id { get; }
        public RemovePartRequest(string id)
        {
            Id = id;
        }
    }
}
