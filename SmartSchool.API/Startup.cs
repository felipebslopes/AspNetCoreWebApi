using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.API.Data;

namespace SmartSchool.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SmartCotext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
                 );

            services.AddScoped<IRepository, Repository>();

            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;

                }
                ).AddApiVersioning(options =>
                {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ReportApiVersions = true;
                }
                );
            services.AddControllers().AddNewtonsoftJson(opt => 
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            var apiProviderDescription = services.BuildServiceProvider()
                .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>
           {
           foreach (var item in apiProviderDescription.ApiVersionDescriptions)
               {
                   options.SwaggerDoc(
               item.GroupName,
                new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "SmartSchool Api",
                    Version = item.ApiVersion.ToString(),
                    TermsOfService = new Uri("https://teste.com"),
                    Description = "A descrição da WebApi do SmartSchool",
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "SmartSchool License",
                        Url = new Uri("http://teste.com")
                    },
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Felipe Lopes",
                        Email = "felipebslopes@gmail.com"
                    }
                }
                );
               }
            
               var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

               options.IncludeXmlComments(xmlCommentsFullPath);

           }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger().UseSwaggerUI(options => {
                foreach (var item in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", item.GroupName.ToUpperInvariant());
                }
                
                options.RoutePrefix = "";
                }
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
