using Abp.Authorization;
using AppBoilerplate.Authorization.Roles;
using AppBoilerplate.Authorization.Users;

namespace AppBoilerplate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
