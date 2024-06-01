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

namespace AgendaDesafios.CrossCutting.AppDependeceInjector
{
    public static class DependeceInjector
    {
        public static void AddInfraestructureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static void AddInfraestructureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhonebookRepository, PhoneBookRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();
        }
        public static void AddServiceInjector(this IServiceCollection services)
        {
            var myHandle = AppDomain.CurrentDomain.Load("AgendaDesafios.Infrastructure");
            services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(myHandle));
        }
    }
}
