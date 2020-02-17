using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Service
{
    public class RemoveServiceRequest : IRequest<RemoveServiceResponse>
    {
        public string Id { get; }
        public RemoveServiceRequest(string id)
        {
            Id = id;
        }
    }
}
