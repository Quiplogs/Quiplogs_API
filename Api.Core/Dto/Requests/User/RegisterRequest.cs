using Api.Core.Dto.Responses.User;
using Api.Core.Interfaces;

namespace Api.Core.Dto.Requests.User
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }
        public string CompanyId { get; }

        public RegisterRequest(string firstName, string lastName, string email, string userName, string password, string companyId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            CompanyId = companyId;
        }
    }
}
