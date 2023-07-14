using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MxStore.Domain.StoreContext.Handlers;
using MxStore.Domain.StoreContext.Repositories;
using MxStore.Domain.StoreContext.Services;
using MxStore.Infra.StoreContext.DataContext;
using MxStore.Infra.StoreContext.Repository;
using MxStore.Infra.StoreContext.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace MxStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.Teste 2
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService> ();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Mx Store", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())            
                app.UseDeveloperExceptionPage();
            
            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mx Store - V1");
            });

        }
    }
}
