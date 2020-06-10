using Autofac;
using RestApi.Service.Facade;

namespace RestApi.Modules
{
    public class ServiceFacadeModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UserServiceFacade>()
                .As<IUserServiceFacade>()
                .SingleInstance();
        }
    }
}