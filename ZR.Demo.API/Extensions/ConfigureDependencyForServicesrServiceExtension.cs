using ZR.Demo.Services.Interfaces;
using ZR.Demo.Services;

namespace ZR.Demo.API.Extensions
{
    public static class ConfigureDependencyForServicesrServiceExtension
    {
        public static void ConfigureDependencyForServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
