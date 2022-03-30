using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UniversidadServicios.Entities.Entities;
using UniversidadServicios.Models.Models;
using UniversidadServicios.Repository.Repository.Airplane;
using UniversidadServicios.Repository.Repository.Country;
using UniversidadServicios.Repository.Repository.Crew;
using UniversidadServicios.Repository.Repository.CrewPerson;
using UniversidadServicios.Repository.Repository.Flight;
using UniversidadServicios.Repository.Repository.Gender;
using UniversidadServicios.Repository.Repository.Luggage;
using UniversidadServicios.Repository.Repository.Person;
using UniversidadServicios.Repository.Repository.Position;
using UniversidadServicios.Repository.Repository.Ticket;
using UniversidadServicios.Repository.Repository.TypeAirplane;
using UniversidadServicios.Repository.Repository.User;
using UniversidadServicios.Repository.Repository.User.Login;
using UniversidadServicios.Repository.Sql.Repository.Sql.Airplane;
using UniversidadServicios.Repository.Sql.Repository.Sql.Country;
using UniversidadServicios.Repository.Sql.Repository.Sql.Crew;
using UniversidadServicios.Repository.Sql.Repository.Sql.CrewPerson;
using UniversidadServicios.Repository.Sql.Repository.Sql.Flight;
using UniversidadServicios.Repository.Sql.Repository.Sql.Gender;
using UniversidadServicios.Repository.Sql.Repository.Sql.Login;
using UniversidadServicios.Repository.Sql.Repository.Sql.Luggage;
using UniversidadServicios.Repository.Sql.Repository.Sql.Person;
using UniversidadServicios.Repository.Sql.Repository.Sql.Position;
using UniversidadServicios.Repository.Sql.Repository.Sql.Ticket;
using UniversidadServicios.Repository.Sql.Repository.Sql.TypeAirplane;
using UniversidadServicios.Repository.Sql.Repository.Sql.User;
using UniversidadServicios.Utility;

namespace UniversidadServicios
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
            services.AddDbContext<UnedProyectosContext>(opt => opt.UseSqlServer("Server=.\\SQLExpress;Database=UnedProyectos;Trusted_Connection=True;"));
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUtility, UtilityHelper>();
            services.AddScoped<IAirplane, AirplaneRepository>();
            services.AddScoped<ICountry, CountryRepository>();
            services.AddScoped<ICrew, CrewRepository>();
            services.AddScoped<ICrewPerson, CrewPersonRepository>();
            services.AddScoped<IFlight, FlightRepository>();
            services.AddScoped<IGender, GenderRepository>();
            services.AddScoped<ILuggage, LuggageRepository>();
            services.AddScoped<IPerson, PersonRepository>();
            services.AddScoped<IPosition, PositionRepository>();
            services.AddScoped<ITicket, TicketRepository>();
            services.AddScoped<ITypeAirplane, TypeAirplaneRepository>();

            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            services.AddSingleton(appSettings);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
