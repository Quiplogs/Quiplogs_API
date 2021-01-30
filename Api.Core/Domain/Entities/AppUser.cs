using System;

namespace Quiplogs.Core.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public Guid? LocationId { get; set; }
        public Location Location { get; set; }
    }
}
