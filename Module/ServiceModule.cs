using Autofac;
using Autofac.Core;

namespace RestApi.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UserService>()
                .Keyed<IUserService>(UserServiceType.UserService)
                .SingleInstance();
            builder
                .RegisterType<UserServiceCore>()
                .Keyed<IUserService>(UserServiceType.UserServiceCore)
                .SingleInstance();
        }
    }
}