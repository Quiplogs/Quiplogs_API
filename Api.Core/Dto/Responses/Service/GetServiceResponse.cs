using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Service
{
    public class GetServiceResponse : ServiceResponseMessage
    {
        public Domain.Entities.Service Service { get; }
        public IEnumerable<Error> Errors { get; }

        public GetServiceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetServiceResponse(Domain.Entities.Service service, bool success = false, string message = null) : base(success, message)
        {
            Service = service;
        }
    }
}
