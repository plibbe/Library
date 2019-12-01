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
        public static async Task<IServiceCollection> AddInfrastructure(this IServiceCollection services)
        {
            var result = await CloudTableService.GetTable("test");

            //DefaultEndpointsProtocol=https;AccountName=azlib;AccountKey=L00YRKyQIz6KEuOmcN2fFwGDqUVkGESIyxOT6PPsPYA5ncGYE7hklSKKgSKG4qKSzBWeXve0SDj4UtsSo1GcSw==;TableEndpoint=https://azlib.table.cosmos.azure.com:443/;
            return services.AddDbContext<LibraryDbContext>(options =>
             options.UseSqlServer(Environment.GetEnvironmentVariable("AzureSQLConnectionString")));
        }
    }
}
