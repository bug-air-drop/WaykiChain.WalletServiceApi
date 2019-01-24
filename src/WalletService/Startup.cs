using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

namespace WalletServiceApi
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
            services.AddMvc(options =>
            {
                //options.Filters.Add<ErrorActionFilter>();

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Version = "v1",
                    Title = "WalletService API",
                    Description = "基于钱包版本: v1.1.1.1",
                });

                //Set the comments path for the swagger json and ui.
                var basePath = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "WalletServiceApi.xml");
                c.IncludeXmlComments(xmlPath);
            });

            IConfiguration nodeConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Add(new JsonConfigurationSource { Path = "nodesettings.json", ReloadOnChange = true })
                .Build();

            services.AddHttpClient();
            var walletNodes = nodeConfig.GetSection("Nodes").Get<List<WalletNodeInfo>>();
            foreach (var node in walletNodes)
            {
                if (!string.IsNullOrEmpty(node.Url))
                {
                    services.AddHttpClient(node.Name, c =>
                    {
                        c.BaseAddress = new Uri(node.Url);
                        c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(node.AuthInfo)));
                    });
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    //app.UseHsts();
            //}

            app.UseDeveloperExceptionPage();
            //app.UseHttpsRedirection();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WalletService API V1");
                c.ShowExtensions();
            });

            app.UseMvc();


        }
    }
}
