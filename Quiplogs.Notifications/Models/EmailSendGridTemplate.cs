using Quiplogs.Notifications.Email.Interfaces;
using Quiplogs.Notifications.Interfaces;
using System.Collections.Generic;

namespace Quiplogs.Notifications.Models
{
    public class EmailSendGridTemplate : IEmailSendGridTemplate, IEmail
    {
        public string TemplateId { get; set; }
        public string FromEmailAddress { get; set; }
        public string ToEmailAddress { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public Dictionary<string,string> Tags { get; set; }
    }
}
