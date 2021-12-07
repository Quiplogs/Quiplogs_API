using System;
using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Responses.Company
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
