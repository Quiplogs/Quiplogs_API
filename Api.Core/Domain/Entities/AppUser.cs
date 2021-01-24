using System;

namespace Api.Core.Domain.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? LocationId { get; set; }
    }
}
