using Quiplogs.Notifications.Email.Interfaces;
using System.Threading.Tasks;

namespace Quiplogs.Notifications.Interfaces
{
    public interface ISendEmailService
    {
        Task SendMail(IEmail email);
    }
}
