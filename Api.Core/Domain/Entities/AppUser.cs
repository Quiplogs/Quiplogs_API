using System;

namespace Quiplogs.Core.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        //Needed to persist correctly
        public string PasswordHash { get; set; }
        public string Password { get; set; }
        public string CurrentPassword { get; set; }
        public string ReenteredPassword { get; set; }
        public string Role { get; set; }
        public Guid? LocationId { get; set; }
        public Location Location { get; set; }
    }
}
