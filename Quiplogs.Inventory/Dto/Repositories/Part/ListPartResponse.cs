using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Inventory.Dto.Repositories.Part
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
