using System.Collections.Generic;

namespace Quiplogs.Core.Dto.Repositories.Location
{
    public class RemoveLocationResponse : BaseRepositoryResponse
    {
        public string Description { get; set; }

        public RemoveLocationResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
