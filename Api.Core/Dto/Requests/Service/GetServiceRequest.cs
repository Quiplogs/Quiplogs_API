using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Service
{
    public class GetServiceRequest : IRequest<GetServiceResponse>
    {
        public string Id { get; }
        public GetServiceRequest(string id)
        {
            Id = id;
        }
    }
}
