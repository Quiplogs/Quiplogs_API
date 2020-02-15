using Api.Core.Domain.Entities;

namespace Api.UseCases.User.Update
{
    public class UpdateUserRequest
    {
        public AppUser User { get; set; }
    }
}
