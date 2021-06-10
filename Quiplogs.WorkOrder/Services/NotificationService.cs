using Microsoft.Extensions.Configuration;
using Quiplogs.Notifications.Interfaces;
using Quiplogs.Notifications.Models;
using Quiplogs.WorkOrder.Interfaces.Services;
using System.Threading.Tasks;

namespace Quiplogs.WorkOrder.Services
{
    public class NotificationService : INotificationService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ISendEmailService _emailService;

        public NotificationService(ISendEmailService emailService, IConfiguration configuration)
        {
            _emailService = emailService;

            var settingsSection = configuration.GetSection("EmailSettings");
            _emailSettings = settingsSection.Get<EmailSettings>();
        }

        public async Task SendMail(EmailSendGridTemplate email)
        {
            var workOrderEmailSettings = _emailSettings.WorkOrder;

            email.TemplateId = workOrderEmailSettings.TemplateId;
            email.Domain = workOrderEmailSettings.Domain;
            email.FromEmailAddress = workOrderEmailSettings.FromEmail;
            email.FromName = workOrderEmailSettings.FromName;

            // Set domain variables in tags
            foreach (var keyValuePair in email.Tags)
            {
                keyValuePair.Value.Replace("{Domain}", workOrderEmailSettings.Domain);
            }

            await _emailService.SendMail(email);
        }
    }
}
