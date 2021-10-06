using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_BAL.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using CRUD_DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace CRUDAppNetCoreWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));  
            services.AddControllers();  
            services.AddHttpClient();  
            services.AddTransient<IRepository<Person>, RepositoryPerson>();  
            services.AddTransient<PersonService, PersonService>();
            services.AddSwaggerGen(c =>  
            {  
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUDAspNetCore5WebAPI", Version = "v1" });  
            });  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())  
            {  
                app.UseDeveloperExceptionPage();  
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUDAspNetCore5WebAPI v1");
                    c.RoutePrefix = string.Empty;
                });
            }  
  
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