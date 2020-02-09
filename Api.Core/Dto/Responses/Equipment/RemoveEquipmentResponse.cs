using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Responses.Equipment
{
    public class RemoveEquipmentResponse : ServiceResponseMessage
    {
        public string Description { get; }
        public IEnumerable<Error> Errors { get; }

        public RemoveEquipmentResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RemoveEquipmentResponse(string description, bool success = false, string message = null) : base(success, message)
        {
            Description = description;
        }
    }
}
