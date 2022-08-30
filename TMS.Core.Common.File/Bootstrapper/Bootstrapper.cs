using Microsoft.Extensions.DependencyInjection;

namespace TMS.Core.Common.File
{
    public static class Bootstrapper
    {
        public static void ResolveFilehelper(IServiceCollection services)
        {
            services.AddScoped<ICommon.File.IFileHelper, FileHelper.FileHelper>();
        }
    }
}
