using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;


namespace Application.Auth
{
    public static class Bootstrapper
    {
        public static void ResolveAppService(IServiceCollection services, IConfiguration configuration)
        {
            Type[] appServices = Assembly.Load(typeof(AppService.AuthAppService).Assembly.GetName()).GetTypes().Where(x => x.IsSubclassOf(typeof(BaseAppService))).ToArray();
            Type[] iAppServices = Assembly.Load(typeof(IAuthAppService).Assembly.GetName()).GetTypes().Where(a => a.IsInterface).ToArray(); ;

            foreach (Type iAppService in iAppServices)
            {
                Type classType = appServices.FirstOrDefault(x => iAppService.IsAssignableFrom(x));

                if (classType != null)
                {
                    services.AddScoped(iAppService, classType);
                }
            }

            Setting.AuthSetting authSettings = new Setting.AuthSetting();
            configuration.Bind("AuthSetting", authSettings);
            services.AddSingleton(authSettings);
        }

     
       
    }
}
