using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System.Reflection;
using Service.VehicleService;
using DataAccess.Repository;
using Service.DataModels;
using Commons;
using DataAccess.Entity;
using WebApi.AutoMapper;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>();
            builder.RegisterType<MakeRepository>().As<IMakeRepository>();
            builder.RegisterType<ModelRepository>().As<IModelRepository>();
            builder.RegisterType<VehicleMake>().As<IVehicleMake>();
            builder.RegisterType<VehicleModel>().As<IVehicleModel>();
            builder.RegisterType<VehicleContext>().AsSelf().InstancePerLifetimeScope();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            })).AsSelf().InstancePerRequest();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var configuration = context.Resolve<MapperConfiguration>();
                return configuration.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);



            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
