using Autofac;
using RestApi.Service;

namespace RestApi.Modules
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

            builder
                .RegisterType<GroupService>()
                .As<IGroupService>()
                .SingleInstance();

            builder
                .RegisterType<UserGroupService>()
                .As<IUserGroupService>()
                .SingleInstance();
        }
    }
}