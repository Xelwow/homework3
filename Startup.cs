using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HomeWork_API.Services.Interfaces;
using HomeWork_API.BusinessLogic;
using HomeWork_API.Services;
using HomeWork_API.Contracts;
using MassTransit;

namespace HomeWork_API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddScoped<GetUsersInfoRequestHandler>();
            services.AddScoped<AppendUserRequestHandler>();
            services.AddScoped<IUserInfoService, UserInfoService>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<AppendUserConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingInMemory(cfg =>
                {

                    cfg.ReceiveEndpoint("submit-order", e =>
                    {
                        e.ConfigureConsumer<AppendUserConsumer>(provider);
                        EndpointConvention.Map<AppendUserContract>(e.InputAddress);
                    });

                    // or, configure the endpoints by convention
                    cfg.ConfigureEndpoints(provider);
                }));

            });
            services.AddHostedService<BusService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
