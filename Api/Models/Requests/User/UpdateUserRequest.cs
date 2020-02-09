using Api.Core.Domain.Entities;

namespace Api.Models.Requests.User
{
    public class UpdateUserRequest
    {
        public AppUser User { get; set; }
    }
}
