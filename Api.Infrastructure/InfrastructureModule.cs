using Api.Core.Interfaces.UseCases;
using Api.Infrastructure.Auth;
using Autofac;
using System.Reflection;

namespace Api.Infrastructure
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
