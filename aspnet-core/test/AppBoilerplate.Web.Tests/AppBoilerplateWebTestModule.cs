using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AppBoilerplate.EntityFrameworkCore;
using AppBoilerplate.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AppBoilerplate.Web.Tests
{
    [DependsOn(
        typeof(AppBoilerplateWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AppBoilerplateWebTestModule : AbpModule
    {
        public AppBoilerplateWebTestModule(AppBoilerplateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AppBoilerplateWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AppBoilerplateWebMvcModule).Assembly);
        }
    }
}