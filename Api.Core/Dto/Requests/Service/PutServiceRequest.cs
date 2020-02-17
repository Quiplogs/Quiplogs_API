using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.Service
{
    public class PutServiceRequest : IRequest<PutServiceResponse>
    {
        public Domain.Entities.Service Service { get; }
        public PutServiceRequest(Domain.Entities.Service service)
        {
            Service = service;
        }
    }
}
