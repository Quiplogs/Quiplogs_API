using Quiplogs.Notifications.EmailService;
using Quiplogs.WorkOrder.Data.Entities;

namespace Quiplogs.WorkOrder.Notifications
{
    public class WokOrderCompleted : Email
    {
        public void WorkOrderCompleted(WorkOrderDto workerOrder)
        {
            Tags = new Tags();
            Tags.FirstName = workerOrder.ResponsableUserName;
            Tags.LastName = "";
        }
    }
}
