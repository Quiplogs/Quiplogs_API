using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Equipment
{
    public class CreateEquipmentResponse : BaseResponse
    {
        public string Id { get; set; }

        public CreateEquipmentResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
