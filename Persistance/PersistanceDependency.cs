using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Data;
using Persistance.Repositories;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceDependency
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<mcContext>(
                o => o.UseSqlServer(configuration.GetConnectionString("mcConnectionString"),
                o => o.MigrationsAssembly("MyCalendar")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IAccesRequestRepository, AccesRequestRepository>();

            return services;
        }

    }
}
