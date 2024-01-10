using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EjercicioPresentacion.Services;
using EjercicioPresentacion.Controllers;

namespace EjercicioPresentacion
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Obtener la cadena de conexión desde la configuración
            string connectionString = Configuration.GetConnectionString("TuConnectionStringKey");

            // Registrar la implementación del servicio en el contenedor de dependencias
            services.AddSingleton<IRegistroDatosService>(provider => new SqlRegistroDatosService(connectionString));

            // Otros servicios y configuraciones
            services.AddControllersWithViews(); // Agrega soporte para controladores y vistas
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configuraciones para entorno de producción
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=RegistroDatos}/{action=MostrarRegistro}/{id?}");
            });
        }
    }
}
