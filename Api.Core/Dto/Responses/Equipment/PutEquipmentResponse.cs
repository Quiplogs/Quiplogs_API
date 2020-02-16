using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Equipment
{
    public class PutEquipmentResponse : ServiceResponseMessage
    {
        public Domain.Entities.Equipment Equipment { get; }
        public IEnumerable<Error> Errors { get; }

        public PutEquipmentResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PutEquipmentResponse(Domain.Entities.Equipment equipment, bool success = false, string message = null) : base(success, message)
        {
            Equipment = equipment;
        }
    }
}
