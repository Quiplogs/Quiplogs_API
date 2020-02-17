using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Responses.Service
{
    public class PutServiceResponse : ServiceResponseMessage
    {
        public Domain.Entities.Service Service { get; }
        public IEnumerable<Error> Errors { get; }

        public PutServiceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutServiceResponse(Domain.Entities.Service service, bool success = false, string message = null) : base(success, message)
        {
            Service = service;
        }
    }
}
