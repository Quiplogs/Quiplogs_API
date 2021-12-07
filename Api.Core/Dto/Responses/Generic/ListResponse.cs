using System.Collections.Generic;
using Quiplogs.Core.Interfaces;

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
