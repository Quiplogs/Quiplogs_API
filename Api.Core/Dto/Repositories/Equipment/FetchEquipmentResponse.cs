using Api.Core.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Repositories.Equipment
{
    public class FetchEquipmentResponse : BaseResponse
    {
        public List<Domain.Entities.Equipment> Equipment { get; set; }

        public FetchEquipmentResponse(List<Domain.Entities.Equipment> equipment, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Equipment = equipment;
        }
    }
}
