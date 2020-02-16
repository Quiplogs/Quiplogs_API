using Api.Core.Dto.Responses;
using System.Collections.Generic;
namespace Api.Core.Dto.Repositories.Part
{
    public class PutPartResponse : BaseResponse
    {
        public Domain.Entities.Part Part { get; set; }

        public PutPartResponse(Domain.Entities.Part part, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Part = part;
        }
    }
}
