using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elmah.Io.AspNetCore;
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
using Microsoft.Extensions.Configuration;
using System.IO;
using MxStore.Shared;

namespace MxStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.Teste 2
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

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

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
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

            app.UseElmahIo("92df7844de344b8a86c04b890f39f26b", new Guid("83ff12da-91e0-4d78-bc88-049b1f7b9af0"));

        }
    }
}
