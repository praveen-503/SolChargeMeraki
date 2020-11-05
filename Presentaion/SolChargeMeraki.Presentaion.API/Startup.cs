using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SolChargeMeraki.Presentaion.API.AutoMapper;
using SolChargeMeraki.Presentaion.API.Extensions;

namespace SolChargeMeraki.Presentaion.API
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
            services.AddControllers();
            services.AddAutoMapper(typeof(AutoMapperProfile)); 
            services.RegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper automapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            foreach (var map in automapper.ConfigurationProvider.GetAllTypeMaps())
            {
                automapper.ConfigurationProvider.AssertConfigurationIsValid(map);
            }
            app.HandleException(); 

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
