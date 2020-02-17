using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Service
{
    public class ListServiceResponse : BaseResponse
    {
        public List<Domain.Entities.Service> Services { get; set; }

        public ListServiceResponse(List<Domain.Entities.Service> services, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Services = services;
        }
    }
}
