using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Location
{
    public class RemoveLocationResponse : BaseResponse
    {
        public string Description { get; set; }

        public RemoveLocationResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
