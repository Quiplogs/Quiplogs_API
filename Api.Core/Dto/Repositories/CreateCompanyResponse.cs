using Api.Core.Dto.Responses;
using System;
using System.Collections.Generic;

namespace Api.Core.Dto.Repositories
{
    public class CreateCompanyResponse : BaseRepositoryResponse
    {
        public string Id { get; set; }

        public CreateCompanyResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
