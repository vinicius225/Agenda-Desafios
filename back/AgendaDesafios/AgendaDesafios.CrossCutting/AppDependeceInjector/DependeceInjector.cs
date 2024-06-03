using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Infrastructure.Repositories;
using System.Data;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Data.SqlClient;
using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Application.Services;
using System.Reflection;

namespace AgendaDesafios.CrossCutting.AppDependeceInjector
{
    public static class DependeceInjector
    {
        public static void AddInfraestructureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_connectionString));

            services.AddScoped<IDbConnection>(_ =>
            {
                var conn = new SqlConnection(_connectionString);
                conn.Open();
                return conn;
            });
        }

        public static void AddInfraestructureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDapperRepository, UserDapperRepository>();

            services.AddScoped<IPhonebookRepository, PhoneBookRepository>();

            services.AddScoped<ICalendarRepository, CalendarRepository>();
        }
        public static void AddServiceInjector(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));;


        }
    }
}
