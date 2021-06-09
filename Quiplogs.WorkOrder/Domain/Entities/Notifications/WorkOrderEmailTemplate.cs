using System.Collections.Generic;
using Quiplogs.Notifications.Models;

namespace Quiplogs.WorkOrder.Domain.Entities.Notifications
{
    public class WorkOrderEmailTemplate : EmailSendGridTemplate
    {
        public WorkOrderEmailTemplate(WorkOrderEntity model, WorkOrderEmailSettings emailSettings)
        {
            Tags = new Dictionary<string, string>();
            Tags.Add("first_name", model.Technician.FirstName);
            Tags.Add("last_name", model.Technician.LastName);
            Tags.Add("work_order_reference_number", model.ReferenceNumber);
            Tags.Add("work_order_link", $"{emailSettings.Domain}{model.Id}");

            TemplateId = emailSettings.TemplateId;
            FromEmail = emailSettings.FromEmail;
            FromName = emailSettings.FromName;
            ToEmail = model.Technician.Email;
            ToName = $"{model.Technician.FirstName} {model.Technician.LastName}";
            Subject = emailSettings.Subject;
        }
    }
}
