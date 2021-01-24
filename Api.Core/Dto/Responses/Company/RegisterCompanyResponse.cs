using Api.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Api.Core.Dto.Responses.Company
{
    public class RegisterCompanyResponse : ServiceResponseMessage
    {
        public Guid Id { get; }
        public IEnumerable<string> Errors { get; }

        public RegisterCompanyResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterCompanyResponse(Guid id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
