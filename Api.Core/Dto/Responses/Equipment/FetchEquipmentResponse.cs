using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Equipment
{
    public class FetchEquipmentResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.Equipment> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public FetchEquipmentResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public FetchEquipmentResponse(PagedResult<Domain.Entities.Equipment> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
