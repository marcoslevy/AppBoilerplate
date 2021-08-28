using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AppBoilerplate.Authorization;

namespace AppBoilerplate
{
    [DependsOn(
        typeof(AppBoilerplateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AppBoilerplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AppBoilerplateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AppBoilerplateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
