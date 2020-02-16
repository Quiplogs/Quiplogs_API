using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Part
{
    public class ListPartResponse : BaseResponse
    {
        public List<Domain.Entities.Part> Parts { get; set; }

        public ListPartResponse(List<Domain.Entities.Part> parts, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Parts = parts;
        }
    }
}
