using ExceptionMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Collections.Generic;
using System.Linq;


namespace Presentation.UploadFileAPI
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
            #region Controller
            services.AddControllers();
            #endregion

            #region Dependency Injection
            Core.Common.File.Bootstrapper.ResolveFilehelper(services);
            WebToken.Bootstrapper.Bootstrapper.ResolveTokenInfo(services, Configuration, false);
            #endregion

            #region Setting
            Setting.UploadSetting setting = new Setting.UploadSetting();
            Configuration.Bind("UploadSetting", setting);
            services.AddSingleton(setting);
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Upload File API", Version = "v1" });
                c.CustomSchemaIds(i => i.FullName);
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
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowAnyOrigin();
                    });
            });
            #endregion

            services.Configure<FormOptions>(x =>
            {
               
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MemoryBufferThreshold = int.MaxValue;
            });
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
            IConfigurationSection SwaggerBasePath = Configuration.GetSection("SwaggerBasePath");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{ SwaggerBasePath.Value}/swagger/v1/swagger.json", "Upload FIle Api V1");
                c.RoutePrefix = string.Empty;
            });
            #endregion

            #region End Point
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }
    }
}
