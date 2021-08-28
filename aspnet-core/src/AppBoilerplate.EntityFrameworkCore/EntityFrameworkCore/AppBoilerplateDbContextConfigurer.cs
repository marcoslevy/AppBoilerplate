using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AppBoilerplate.EntityFrameworkCore
{
    public static class AppBoilerplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AppBoilerplateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AppBoilerplateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
