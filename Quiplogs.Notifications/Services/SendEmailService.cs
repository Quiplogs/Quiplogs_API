using Quiplogs.Notifications.Email.Interfaces;
using Quiplogs.Notifications.Interfaces;
using Quiplogs.Notifications.Send.Interfaces;
using System.Threading.Tasks;

namespace Quiplogs.Notifications.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly ISendService _sendService;

        public SendEmailService(ISendService sendService)
        {
            _sendService = sendService;
        }

        public async Task SendMail(IEmail email)
        {
            await _sendService.SendNotification(email);
        }
    }
}
