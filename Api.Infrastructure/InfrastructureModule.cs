using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.Repositories.Equipment;
using Api.Core.Interfaces.Repositories.Location;
using Api.Core.Interfaces.Repositories.User;
using Api.Core.Interfaces.UseCases;
using Api.Infrastructure.Auth;
using Api.Infrastructure.Repositories;
using Autofac;

namespace Api.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EquipmentRepository>().As<IEquipmentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LocationRepository>().As<ILocationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
