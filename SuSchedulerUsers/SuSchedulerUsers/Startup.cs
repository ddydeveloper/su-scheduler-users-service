using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SuSchedulerUsers.Services;
using SuSchedulerUsers.Settings;
using Swashbuckle.AspNetCore.Swagger;

namespace SuSchedulerUsers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.File($"{AppContext.BaseDirectory}/Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq(configuration.GetConnectionString("Seq"))
                .CreateLogger();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Users Service", Version = "v1", });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("All", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });
            
            services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));
            services.AddScoped<IUsersService, UsersService>();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("All")
                .UseHttpsRedirection()
                .UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger/ui";
            });
        }
    }
}