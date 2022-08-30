using Microsoft.Extensions.DependencyInjection;

namespace Core.Common.File
{
    public static class Bootstrapper
    {
        public static void ResolveFilehelper(IServiceCollection services)
        {
            services.AddScoped<IFileHelper, FileHelper>();
        }
    }
}
