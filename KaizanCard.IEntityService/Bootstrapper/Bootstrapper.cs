using Lean.Data.IEntityService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Lean.Data.EntityService
{ 
    public static class Bootstrapper
    {
        public static void ResolveEntityService(IServiceCollection services)
        {
            Type[] appServices = Assembly.Load(typeof(KaizanCardEntityHeaderService).Assembly.GetName()).GetTypes().Where(x => x.IsSubclassOf(typeof(Base.BaseEntityService))).ToArray();
            Type[] iAppServices = Assembly.Load(typeof(IKaizenCardHeadrEntityService).Assembly.GetName()).GetTypes().Where(a => a.IsInterface).ToArray();

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
