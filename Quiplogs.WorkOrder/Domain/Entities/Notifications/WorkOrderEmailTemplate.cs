using System.Collections.Generic;
using Quiplogs.Notifications.Models;

namespace Quiplogs.WorkOrder.Domain.Entities.Notifications
{
    public class WorkOrderEmailTemplate : EmailSendGridTemplate
    {
        public WorkOrderEmailTemplate(WorkOrderEntity model)
        {
            Tags = new Dictionary<string, string>
            {
                {"first_name", model.Technician.FirstName},
                {"last_name", model.Technician.LastName},
                {"work_order_reference_number", model.ReferenceNumber},
                {"work_order_link", "{Domain}" + model.Id}
            };

            ToEmailAddress = model.Technician.Email;
            ToName = $"{model.Technician.FirstName} {model.Technician.LastName}";
        }
    }
}
