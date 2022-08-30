using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExceptionMiddleware;
using Serilog;
using Data.Auth.EntityService;

namespace Presentation.AuthWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string AllowedOrigins { get; } = "AllowedOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            Core.Common.Password.Bootstrapper.ResolvePasswordHelper(services);
            Application.Auth.Bootstrapper.ResolveAppService(services, Configuration);
            Repository.Data.Bootstrapper.ResolveUnitOfWork(services, Configuration);
            WebToken.Bootstrapper.Bootstrapper.ResolveTokenInfo(services, Configuration);
            WebToken.Bootstrapper.Bootstrapper.ResolveTokenGenerator(services, Configuration);
            Resources.Bootstrapper.ResolveMessages(services);
            Bootstrapper.ResolveEntityService(services);
            Application.BackEnd.Bootstrapper.ResolveAppService(services, Configuration);

            Lean.Data.EntityService.Bootstrapper.ResolveEntityService(services);
           

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });
            #endregion

            #region CORS
            IConfigurationSection originsSection = Configuration.GetSection("AllowedOrigins");
            string[] origns = originsSection.AsEnumerable().Where(s => s.Value != null).Select(a => a.Value).ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowedOrigins,
                    builder =>
                    {
                        builder.WithOrigins(origns)
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region env
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #endregion

            #region CORS
            app.UseCors(AllowedOrigins);
            #endregion

            #region App Builder
            app.UseHttpsRedirection();

           app.UseSerilogRequestLogging();
            app.UseExceptionMiddleware();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                IConfigurationSection SwaggerBasePath = Configuration.GetSection("SwaggerBasePath");
                c.SwaggerEndpoint($"{ SwaggerBasePath.Value}/swagger/v1/swagger.json", "Auth management Api v1");
                c.RoutePrefix = string.Empty;
            });
            #endregion

            #region End point
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }
    }
}
