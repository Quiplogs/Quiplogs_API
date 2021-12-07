using Autofac;
using Quiplogs.Notifications.Interfaces;
using Quiplogs.Notifications.Services;

namespace Quiplogs.Notifications
{
    public class NotificationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SendEmailService>().As<ISendEmailService>().InstancePerLifetimeScope();
        }
    }
}
