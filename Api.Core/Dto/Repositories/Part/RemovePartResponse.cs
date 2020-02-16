using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Part
{
    public class RemovePartResponse : BaseResponse
    {
        public string Description { get; set; }

        public RemovePartResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
