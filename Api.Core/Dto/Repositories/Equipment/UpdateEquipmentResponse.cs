using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.Equipment
{
    public class UpdateEquipmentResponse : BaseResponse
    {
        public Domain.Entities.Equipment Equipment { get; set; }

        public UpdateEquipmentResponse(Domain.Entities.Equipment equipment, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Equipment = equipment;
        }
    }
}
