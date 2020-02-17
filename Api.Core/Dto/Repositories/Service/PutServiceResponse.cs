using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Service
{
    public class PutServiceResponse : BaseResponse
    {
        public Domain.Entities.Service Service { get; set; }

        public PutServiceResponse(Domain.Entities.Service service, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Service = service;
        }
    }
}
