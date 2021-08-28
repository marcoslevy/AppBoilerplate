using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AppBoilerplate.Controllers
{
    public abstract class AppBoilerplateControllerBase: AbpController
    {
        protected AppBoilerplateControllerBase()
        {
            LocalizationSourceName = AppBoilerplateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
