using Api.Core.Helpers;
using Api.Core.Interfaces.UseCases;
using Api.Core.Interfaces.UseCases.User;
using Api.Core.UseCases;
using Api.Core.UseCases.User;
using Autofac;

namespace Api.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUseCase>().As<IRegisterUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterCompanyUseCase>().As<IRegisterCompanyUseCase>().InstancePerLifetimeScope();

            //Users
            builder.RegisterType<FetchUsersUseCase>().As<IFetchUsersUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetUserUseCase>().As<IGetUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateUserUseCase>().As<IUpdateUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RemoveUserUseCase>().As<IRemoveUserUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<Caching>().As<ICaching>().InstancePerLifetimeScope();
        }
    }
}
