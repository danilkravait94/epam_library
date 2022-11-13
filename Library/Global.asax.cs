using Library.BLL.Infrastructure;
using Library.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Library
{
    /// <summary>
    /// application start class
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// start method
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           // NinjectModule registration = new NinjectRegistrations();
            //var kernel = new StandardKernel(registration);

            NinjectModule serviceModule = new ServiceModule(/*"DBConnection"*/);
            NinjectModule assaymodule = new AssayModule();
            NinjectModule formModule = new FormModule();
            NinjectModule reviewModule = new ReviewModule();
            var kernel = new StandardKernel(serviceModule, assaymodule,formModule,reviewModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
