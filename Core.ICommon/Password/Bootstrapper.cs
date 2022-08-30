using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Password
{
    public static class Bootstrapper
    {
        public static void ResolvePasswordHelper(IServiceCollection services)
        {
            services.AddScoped<IPasswordHelper, PasswordHelper>();
        }
    }
}
