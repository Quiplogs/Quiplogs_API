using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Quiplogs.Core.Dto.Requests.User
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string UserName { get; }
        public string Password { get; }
        public LoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
