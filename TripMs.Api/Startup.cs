using TripMs.Data.Context;
using TripMs.Infra.Ioc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace TripMs.Api
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

            services.AddDbContext<TripMsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
            });


            //
            services.AddMediatR(typeof(Startup));

            //
            services.AddControllers();

            //
            services.AddAutoMapper(typeof(Startup));

            //
            RegisterService(services);

            // Cors Origin configuring
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAll",
                    options =>
                    options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            //
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

        }


        //Register Ioc Dependency Container
        private void RegisterService(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //swagger in Dev
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Energie Monitoring V1");
                });

            }
            else
            {
                var path = Environment.GetEnvironmentVariable("service");
                var basePath = ":31633/" + Environment.GetEnvironmentVariable("service");
                app.UseExceptionHandler("/Error");
                app.UseSwagger(c =>
                {

                    c.RouteTemplate = "swagger/{documentName}/swagger.json";
                    c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}"}
                    });

                });

                var endpoint = "/" + path + "/swagger/v1/swagger.json";
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(endpoint, "API V1");
                });


            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TripMs API");
            });

            //
            app.UseCors("AllowAll");

            //
            app.UseRouting();

            //
            app.UseAuthorization();

            //
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
