using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Web.API.Service;
using Web.API.Service.DTO;
using Web.API.Service.Interfaces;
using Web.API.ViewModels;

namespace Web.API
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
            services.AddSingleton(cfg => Configuration);

            #region Configurando AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {                
                cfg.CreateMap<UserViewModel, UserDTO>().ReverseMap();                
            });
            
            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion             
            
            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Configurando Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "User API",
                    Version = "v1",
                    Description = "API web que valida se uma senha é valida.",
                    Contact = new OpenApiContact
                    {
                        Name = "Thyago Gonçalves",
                        Email = "gthyago185@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/thyago-gon%C3%A7alves-28942b94/")
                    },
                }) ;
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            //Ativa o Swagger
            app.UseSwagger();
            // Ativa o Swagger UI
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web.API v1"));

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
