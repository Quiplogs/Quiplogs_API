using System.Collections.Generic;

namespace Api.Core.Dto.Repositories
{
    public abstract class BaseRepositoryResponse
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }

        protected BaseRepositoryResponse(bool success = false, IEnumerable<Error> errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }
}
