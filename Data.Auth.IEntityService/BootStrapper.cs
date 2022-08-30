using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;


namespace Data.Auth.EntityService
{
    public static class Bootstrapper
    {
        public static void ResolveEntityService(IServiceCollection services)
        {
            Type[] appServices = Assembly.Load(typeof(AuthEntityService).Assembly.GetName()).GetTypes().Where(x => x.IsSubclassOf(typeof(BaseAuthEntityService))).ToArray();
            Type[] iAppServices = Assembly.Load(typeof(IAuthEntityService).Assembly.GetName()).GetTypes().Where(a => a.IsInterface).ToArray();
            foreach (Type iAppService in iAppServices)
            {
                Type classType = appServices.FirstOrDefault(x => iAppService.IsAssignableFrom(x));
                if (classType != null)
                {
                    services.AddScoped(iAppService, classType);
                }
            }
        }
    }
}
