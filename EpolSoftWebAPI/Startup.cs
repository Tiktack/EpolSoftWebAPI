using System;
using System.Net;
using System.Text.Json;
using EpolSoft.WebAPI.DTOs;
using EpolSoft.WebAPI.Utils.Filters;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace EpolSoft.WebAPI
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

            services.AddControllers(options =>
            {
                //Add model validation filter to avoid manual checking in every controller
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(c =>
            {
                c.RegisterValidatorsFromAssemblyContaining<Startup>();
                c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
                c.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EpolSoftWebAPI", Version = "v1" });
                c.AddFluentValidationRules();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHealthChecks();

            services.RegisterWeb(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EpolSoftWebAPI v1"));

                // Automaticaly migrating db in dev env (automigrations from ef is evil)
                UpdateDatabase(app);

                app.UseExceptionHandler(a => a.Run(async context =>
                {
                    var message = context.Features.Get<IExceptionHandlerPathFeature>().Error.Message;

                    var response = new Response
                    {
                        Success = false,
                        ErrorMessage = message
                    };

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }));
            }

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler(a => a.Run(async context =>
                {

                    var response = new Response()
                    {
                        Success = false,
                        ErrorMessage = "Inner Exception"
                    };

                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DbContext>();
            context.Database.Migrate();
        }
    }
}
