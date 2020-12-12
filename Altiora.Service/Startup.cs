using Altiora.BusinessLogic;
using Altiora.DataAccess;
using Altiora.Models;
using Altiora.Models.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

namespace Altiora.Service
{
    /// <summary>
    /// Inicio
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">configuraciones</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuraciones
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configuracion de servicio
        /// </summary>
        /// <param name="services">Servicio</param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Ejercicio de Desarrollo de Software Altiora",
                    Version = "v1",
                    Description = "La aplicación debe gestionar un listado de Clientes, " +
                                  "cada uno con Órdenes compuestas de Artículos.Para el Cliente, " +
                                  "interesa registrar su nombre y apellido; para una Orden, su fecha y sus Artículos." +
                                  "Y para cada Artículo, un código, un nombre y un precio unitario", 
                    Contact = new OpenApiContact()
                    {
                        Name = "Santiago Almeida",
                        Email = "santiagoalmeidaburbano@hotmail.com"
                    }
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
            services.AddDbContext<AltioraDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("Default"),
                    x => x.MigrationsAssembly("Altiora.DataAccess")
                    )
                );

            services.AddTransient<IServicioCliente, LogicaCliente>();
            services.AddTransient<IServicioOrden, LogicaOrden>();
            services.AddTransient<IServicioArticulo, LogicaArticulo>();
        }

        /// <summary>
        /// Configuracion
        /// </summary>
        /// <param name="app">Constructor Aplicacion</param>
        /// <param name="env">Entorno</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Altiora.Service v1"));
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
