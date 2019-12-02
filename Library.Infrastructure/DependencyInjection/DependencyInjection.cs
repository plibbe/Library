using Library.Infrastructure.Persistence.EFCoreDbContexts;
using Library.Infrastructure.Persistence.TableStorage.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
             return services.AddDbContext<LibraryDbContext>(options =>
             options.UseSqlServer(Environment.GetEnvironmentVariable("AzureSQLConnectionString")));
        }
    }
}
