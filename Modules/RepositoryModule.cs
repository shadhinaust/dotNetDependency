using Autofac;
using RestApi.Repository;

namespace RestApi.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UserRepository>()
                .As<IUserRepository>()
                .SingleInstance();

            builder
                .RegisterType<GroupRepository>()
                .As<IGroupRepository>()
                .SingleInstance();

            builder
                .RegisterType<UserGroupRepository>()
                .As<IUserGroupRepository>()
                .SingleInstance();
        }
    }
}