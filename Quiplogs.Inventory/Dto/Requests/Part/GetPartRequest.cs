using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Responses.Part;

namespace Quiplogs.Inventory.Dto.Requests.Part
{
    public class GetPartRequest : IRequest<GetPartResponse>
    {
        public string Id { get; }
        public GetPartRequest(string id)
        {
            Id = id;
        }
    }
}
