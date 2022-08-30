
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
   public class Bootstrapper
    {
        public static void ResolveMessages(IServiceCollection services)
        {
            services.AddScoped<IMessageResourceReader, MessageResourceReader>();
        }

    }
}
