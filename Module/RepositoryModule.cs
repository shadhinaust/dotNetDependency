using Autofac;

namespace RestApi.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UserRepository>()
                .As<IUserRepository>()
                .SingleInstance();
        }
    }
}