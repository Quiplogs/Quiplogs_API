using Api.Core.Helpers;
using Api.Core.Interfaces.UseCases;
using Api.Core.Interfaces.UseCases.Equipment;
using Api.Core.Interfaces.UseCases.Location;
using Api.Core.Interfaces.UseCases.User;
using Api.Core.UseCases;
using Api.Core.UseCases.Equipment;
using Api.Core.UseCases.Location;
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

            //Equipment
            builder.RegisterType<FetchEquipmentUseCase>().As<IFetchEquipmentUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetEquipmentUseCase>().As<IGetEquipmentUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PutEquipmentUseCase>().As<IPutEquipmentUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RemoveEquipmentUseCase>().As<IRemoveEquipmentUseCase>().InstancePerLifetimeScope();

            //Location
            builder.RegisterType<ListLocationUseCase>().As<IListLocationUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetLocationUseCase>().As<IGetLocationUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PutLocationUseCase>().As<IPutLocationUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RemoveLocationUseCase>().As<IRemoveLocationUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<Caching>().As<ICaching>().InstancePerLifetimeScope();
        }
    }
}
