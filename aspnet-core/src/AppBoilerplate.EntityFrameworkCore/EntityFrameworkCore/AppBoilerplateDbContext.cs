using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AppBoilerplate.Authorization.Roles;
using AppBoilerplate.Authorization.Users;
using AppBoilerplate.MultiTenancy;

namespace AppBoilerplate.EntityFrameworkCore
{
    public class AppBoilerplateDbContext : AbpZeroDbContext<Tenant, Role, User, AppBoilerplateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AppBoilerplateDbContext(DbContextOptions<AppBoilerplateDbContext> options)
            : base(options)
        {
        }
    }
}
