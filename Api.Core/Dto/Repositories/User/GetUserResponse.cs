﻿using Api.Core.Domain.Entities;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.User
{
    public class GetUserResponse : BaseResponse
    {
        public AppUser User { get; set; }

        public GetUserResponse(AppUser user, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            User = user;
        }
    }
}
