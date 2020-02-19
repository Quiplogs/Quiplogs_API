using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Task
{
    public class RemoveTaskResponse : BaseResponse
    {
        public string Description { get; set; }

        public RemoveTaskResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
