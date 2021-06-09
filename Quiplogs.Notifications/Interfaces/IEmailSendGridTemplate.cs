using System.Collections.Generic;

namespace Quiplogs.Notifications.Interfaces
{
    public interface IEmailSendGridTemplate
    {
        string TemplateId { get; set; }
        string FromEmail { get; set; }
        string ToEmail { get; set; }
        string FromName { get; set; }
        string ToName { get; set; }
        string Subject { get; set; }
        Dictionary<string, string> Tags { get; set; }
    }
}
