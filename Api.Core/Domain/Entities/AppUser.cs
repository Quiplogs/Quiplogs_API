namespace Api.Core.Domain.Entities
{
    public class AppUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
    }
}
