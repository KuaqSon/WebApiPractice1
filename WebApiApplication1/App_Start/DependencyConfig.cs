using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CrawlerService.Interfaces;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApiApplication1
{
    public class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            
            //builder.RegisterAssemblyModules(typeof(ApiController).Assembly);

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            // register controller here
            builder.RegisterType<Crawler>().As<ICrawler>();
            builder.RegisterType<VnExpressParser>().As<IVnExpressParser>();

            //builder.RegisterType<Controllers.CrawlerController>();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); -->> for MVC
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}