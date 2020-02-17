using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Service
{
    public class RemoveServiceResponse : BaseResponse
    {
        public string Description { get; set; }

        public RemoveServiceResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
