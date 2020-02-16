﻿using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Part
{
    public class GetPartResponse : ServiceResponseMessage
    {
        public Domain.Entities.Part Part { get; }
        public IEnumerable<Error> Errors { get; }

        public GetPartResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetPartResponse(Domain.Entities.Part part, bool success = false, string message = null) : base(success, message)
        {
            Part = part;
        }
    }
}