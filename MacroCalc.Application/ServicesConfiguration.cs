using MacroCalc.Application.Interfaces;
using MacroCalc.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MacroCalc.Application;
public static class ApplicationServicesConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMacroEntriesService, MacroEntriesService>();
        return services;
    }
}
