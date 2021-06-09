using System.Collections.Generic;
using Quiplogs.Notifications.Interfaces;

namespace Quiplogs.Notifications.Models
{
    public class EmailSendGridTemplate : IEmailSendGridTemplate
    {
        public string TemplateId { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public Dictionary<string,string> Tags { get; set; }
    }
}
