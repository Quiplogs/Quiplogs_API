using Api.Core.Dto;
using Api.Core.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Core.Dto.Responses.Generic
{
    public class ListResponse<T> : ServiceResponseMessage
    {
        public List<T> ModelList { get; }
        public IEnumerable<Error> Errors { get; }

        public ListResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ListResponse(List<T> modelList, bool success = false, string message = null) : base(success, message)
        {
            ModelList = modelList;
        }
    }
}
