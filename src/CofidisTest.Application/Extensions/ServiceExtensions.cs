using CofidisTest.Application.Services;
using CofidisTest.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CofidisTest.Application.Extensions;

public static class ServiceExtensions
{
    public static void AddCofidisApplication(this IServiceCollection services, IConfiguration config)
    {
        services.AddCofidisData(config);

        services
            .AddTransient<ICreditService, CreditService>()
            .AddTransient<IRiskAssessmentService, RiskAssessmentService>()
            ;
    }
}