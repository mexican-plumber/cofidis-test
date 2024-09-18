using CofidisTest.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CofidisTest.Data.Extensions;

public static class ServiceExtensions
{
    public static void AddCofidisData(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<CofidistTestContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("CofidisTestDatabase")));

        services
            .AddTransient<ICustomerRepository, CustomerRepository>()
            .AddTransient<ICreditLimitRepository, CreditLimitRepository>()
            ;
    }
}