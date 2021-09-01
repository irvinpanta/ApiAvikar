using Api.Core;
using Api.Core.Custom;
using Api.Core.Filters;
using Api.Core.Repositories;
using Api.Core.Repositories.Interface;
using Api.Core.Services;
using Api.Core.Services.Interface;
using Api.Models;
using Api.Models.Dto;
using Api.Models.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrvinPantaApi
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
            services.AddControllers(options => {

            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; //Ignora referencias ciruculares
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; //Ignorar propiedades nulas al cargar Json
            })
           .ConfigureApiBehaviorOptions(options =>
           {
                //options.SuppressModelStateInvalidFilter = true; //Inhabilita en Validation de ApiController
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IrvinPantaApi", Version = "v1" });
            });

            //Pagination
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination")); //Configue Default Pagination options
            services.Configure<PasswordOptions>(Configuration.GetSection("PasswordOptions"));
            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Realizar Mapeos
            //Context de la base de datos
            services.AddDbContext<SisAvikarDemoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("conexion")));

            //Repository
            services.AddTransient<IBaseRepository<SalonModel>, SalonRepository>(); //Salones
            services.AddTransient<IBaseRepository<MesaModel>, MesaRepository>(); //Mesas
            services.AddTransient<IBaseRepository<RolModel>, RolRepository>(); //Roles
            services.AddTransient<IBaseRepository<EmpleadoModel>, EmpleadoRepository>(); //Empleados
            services.AddTransient<ISecurityRepository, SecurityRepository>(); //Credenciales de acceso

            //Services

            services.AddTransient<IBaseService<SalonDto>, SalonService>(); //Salones
            services.AddTransient<IMesaService, MesaService>(); //Mesas
            services.AddTransient<IBaseService<RolDto>, RolService>(); //Roles
            services.AddTransient<IBaseService<EmpleadoModel>, EmpleadoService>(); //Empleados
            
            services.AddTransient<ISecurityService, SecurityService>(); //Credenciales de acceso
            services.AddSingleton<IPasswordService, PasswordService>();


            //JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true, //Validar Emisor
                    ValidateAudience = true, //Validar Audiencia
                    ValidateLifetime = true, //Validar tiempo
                    ValidateIssuerSigningKey = true, //Validar la firma del emisor
                    ValidIssuer = Configuration["Authentication:Issuer"], //Accdemos a valores que tenems en el appsetting.json
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:Secretkey"])) //Secret Key

                };
            });

            //MVC
            services.AddMvc(options =>
            {
                //options.Filters.Add<FiltersValidation>(); //Validamos filtros de forma global

            }).AddFluentValidation(options =>
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()) //Registramos los Validators con FluentValidation
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IrvinPantaApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); //JWT
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
