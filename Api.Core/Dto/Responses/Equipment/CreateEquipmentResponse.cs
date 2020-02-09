using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Equipment
{
    public class CreateEquipmentResponse : ServiceResponseMessage
    {
        public string Id { get; }
        public IEnumerable<Error> Errors { get; }

        public CreateEquipmentResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public CreateEquipmentResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
