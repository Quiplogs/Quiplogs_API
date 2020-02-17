using Api.Core.Domain.Entities;
using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Dto.Responses.Service
{
    public class ListServiceResponse : ServiceResponseMessage
    {
        public PagedResult<Domain.Entities.Service> PagedResult { get; }
        public IEnumerable<Error> Errors { get; }

        public ListServiceResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListServiceResponse(PagedResult<Domain.Entities.Service> pagedResult, bool success = false, string message = null) : base(success, message)
        {
            PagedResult = pagedResult;
        }
    }
}
