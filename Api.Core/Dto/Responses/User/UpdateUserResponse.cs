using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Responses.User
{
    public class UpdateUserResponse : WorkOrderResponseMessage
    {
        public AppUser User { get; }
        public IEnumerable<Error> Errors { get; }

        public UpdateUserResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public UpdateUserResponse(AppUser user, bool success = false, string message = null) : base(success, message)
        {
            User = user;
        }
    }
}
