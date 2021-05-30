using MGK.ServiceTemplate.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.Extensions
{
	public static class DbMigrationsExtensions
    {
        public static void RunDbMigrations(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            serviceProvider.Run<ProofOfConceptContext>();
		}

        private static void Run<TContext>(this IServiceProvider serviceProvider)
            where TContext : DbContext
        {
            using var context = serviceProvider.GetRequiredService<TContext>();
            context.Database.Migrate();
        }
    }
}
