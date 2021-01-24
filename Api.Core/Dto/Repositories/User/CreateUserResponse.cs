using System;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories.User
{
    public class CreateUserResponse : BaseRepositoryResponse
    {
        public Guid Id { get; set; }

        public CreateUserResponse(Guid id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
