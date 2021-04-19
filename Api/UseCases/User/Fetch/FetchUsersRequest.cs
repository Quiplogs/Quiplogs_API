using System;

namespace Api.UseCases.User.Fetch
{
    public class FetchUsersRequest
    {
        public Guid CompanyId { get; set; }
        public Guid? LocationId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
