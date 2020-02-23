using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Responses.Company
{
    public class RegisterCompanyResponse : WorkOrderResponseMessage
    {
        public string Id { get; }
        public IEnumerable<string> Errors { get; }

        public RegisterCompanyResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterCompanyResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
