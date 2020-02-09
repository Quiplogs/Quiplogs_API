using Api.Core.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Repositories.Equipment
{
    public class RemoveEquipmentResponse : BaseResponse
    {
        public string EquipmentDescription { get; set; }

        public RemoveEquipmentResponse(string equipmentDescription, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            EquipmentDescription = equipmentDescription;
        }
    }
}
