using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Responses.Equipment
{
    public class GetEquipmentResponse : ServiceResponseMessage
    {
        public Domain.Entities.Equipment Equipment { get; }
        public IEnumerable<Error> Errors { get; }

        public GetEquipmentResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetEquipmentResponse(Domain.Entities.Equipment equipment, bool success = false, string message = null) : base(success, message)
        {
            Equipment = equipment;
        }
    }
}
