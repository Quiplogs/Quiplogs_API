using Autofac;

namespace Quiplogs.BlobStorage
{
    public class BlobStorageModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlobStorage>().As<IBlobStorage>().InstancePerLifetimeScope();
        }
    }
}
