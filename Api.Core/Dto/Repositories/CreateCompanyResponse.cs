using System;
using System.Collections.Generic;

namespace Quiplogs.Core.Dto.Repositories
{
    public class CreateCompanyResponse : BaseRepositoryResponse
    {
        public Guid Id { get; set; }

        public CreateCompanyResponse(Guid id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
