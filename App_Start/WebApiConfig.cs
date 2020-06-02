using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using CommonServiceLocator;
using RestApi.Repository;
using RestApi.Service;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace RestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Basic Logging
            SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = true;
            traceWriter.MinimumLevel = TraceLevel.Debug;


            // Dependency Injection
            var builder = new ContainerBuilder();
            builder
                .RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterType<UserService>()
                .Keyed<IUserService>(UserServiceType.UserService)
                .SingleInstance();

            builder
                .RegisterType<UserServiceCore>()
                .Keyed<IUserService>(UserServiceType.UserServiceCore)
                .SingleInstance();

            builder
                .RegisterType<UserRepository>()
                .As<IUserRepository>()
                .SingleInstance();
            /*
            builder
                .RegisterModule(new RepositoryModule());
            builder
                .RegisterModule(new ServiceModule()); 
                
             */

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            // Service Locator
            var commonServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(()=>commonServiceLocator);


            // Routing
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
