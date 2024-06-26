﻿using System;
using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.User
{
    public class RegisterResponse : ServiceResponseMessage
    {
        public Guid Id { get; }
        public IEnumerable<Error> Errors { get; }

        public RegisterResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterResponse(Guid id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
