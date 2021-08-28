using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AppBoilerplate.Configuration;

namespace AppBoilerplate.Web.Host.Startup
{
    [DependsOn(
       typeof(AppBoilerplateWebCoreModule))]
    public class AppBoilerplateWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AppBoilerplateWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AppBoilerplateWebHostModule).GetAssembly());
        }
    }
}
