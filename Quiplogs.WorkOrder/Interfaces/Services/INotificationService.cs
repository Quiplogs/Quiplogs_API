using Quiplogs.Notifications.Models;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Interfaces.Services
{
    public interface INotificationService
    {
        Task SendMail(EmailSendGridTemplate email);
    }
}
