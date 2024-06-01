using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.CrossCutting.AppDependeceInjector
{
    public static class DependeceInjector
    {
        public static void AddInfraestructureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
        }
        public static void AddInfraestructureRepository(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository>();
        }
    }
}
