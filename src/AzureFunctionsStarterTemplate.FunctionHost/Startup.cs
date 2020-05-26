using AzureFunctionsStarterTemplate.Bll;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionsStarterTemplate.FunctionHost.Startup))]
namespace AzureFunctionsStarterTemplate.FunctionHost
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddSingleton<WorkerService>();
        }
    }
}