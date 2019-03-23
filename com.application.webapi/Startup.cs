using com.application.business.Managers;
using com.application.business.Mappers;
using com.application.business.Wrappers;
using com.application.contracts.Common;
using com.application.contracts.Managers;
using com.application.contracts.Repository;
using com.application.data;
using com.application.data.Mappers;
using com.application.data.Repository;
using com.application.entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.application.webapi
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {

            _hostingEnvironment = hostingEnvironment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(_ => new universaldbEntities());

            //Managers
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IDepartmentManager, DepartmentManager>();

            //Repositoty
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            //Mappers
            services.AddSingleton<IMapper<EmployeeSaveMapperWrapper, Employee>, EmployeeSaveMapper>();


            services.AddSingleton<IEntityMapper, EntityMapper>();
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
