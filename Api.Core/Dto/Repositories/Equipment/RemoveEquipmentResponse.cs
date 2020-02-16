using Api.Core.Dto.Responses;
using System.Collections.Generic;

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
