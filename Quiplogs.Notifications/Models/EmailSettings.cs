namespace Quiplogs.Notifications.Models
{
    public class EmailSettings
    {
        public WorkOrderEmailSettings WorkOrder { get; set; }
    }

    public class WorkOrderEmailSettings
    {
        public string TemplateId { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
    }
}
