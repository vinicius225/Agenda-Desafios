using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Infrastructure.Repositories;
using System.Data;
using Microsoft.Data.SqlClient;

using System.Reflection;
using AgendaDesafios.Application.Login.Queries;
using AgendaDesafios.Application.DTOs;
using MediatR;
using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Application.Services;

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
            services.AddScoped<IPhonebookRepository, PhoneBookRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();


            services.AddScoped<IUserDapperRepository, UserDapperRepository>();
            services.AddScoped<IPhonebookDapperRepository, PhonebookDapperRepository>();
            services.AddScoped<ICalendarDapperRepository, CalendarDapperRepository>();


        }
        public static void AddServiceInjector(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoggerService, LoggerService>();

        }

    }
}
