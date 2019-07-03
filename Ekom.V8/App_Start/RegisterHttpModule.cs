using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EkomV8.App_Start.RegisterHttpModule), "RegisterModules")]
namespace EkomV8.App_Start
{
    /// <summary>
    /// Registers the Ekom HttpModule into the request pipeline.
    /// This eliminates the explicit web.config/system.webserver/modules configuration 
    /// </summary>
    static class RegisterHttpModule
    {
        /// <summary>
        /// Registers the Ekom HttpModule into the request pipeline.
        /// This eliminates the explicit web.config/system.webserver/modules configuration 
        /// </summary>
        public static void RegisterModules()
        {
            DynamicModuleUtility.RegisterModule(typeof(HttpModule));
        }
    }
}
