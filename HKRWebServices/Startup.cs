using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HKRInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using StructureMap;
using System.Diagnostics;
using HKRCore.Model;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;

namespace HKRWebServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddControllersAsServices();
            // AutoMapper
            services.AddAutoMapper();
            //Swagger generation
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1", new Info { Title = "HKR API", Version = "v1" } );
            } );
            /*var config = new AutoMapper.MapperConfiguration( cfg =>
            {
                cfg.AddProfile( new UserProfile() );
            } );

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>( mapper );*/
            //The database context
            services.AddDbContext<HKRContext>( opt => opt.UseInMemoryDatabase("HKRMemDB") );
            return ConfigureIoC( services );

        }

        private IServiceProvider ConfigureIoC( IServiceCollection services )
        {
            var container = new Container();

            container.Configure( config =>
                {
                    config.Scan( _ =>
                    {
                        // Gets all assemblies
                        _.AssembliesFromApplicationBaseDirectory();
                        // Class for IClass
                        _.WithDefaultConventions();
                        // If it has a single implementation...
                        _.SingleImplementationsOfInterface();

                    } );

                    config.Populate( services );
                }
            );
            /* To get a report of what is in the container in debug
            var report = container.WhatDoIHave();

            Debug.WriteLine( report );
            */
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json", "HKR API V1" );
            } );
        }
    }
}
