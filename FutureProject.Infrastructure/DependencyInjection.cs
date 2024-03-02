using FutureProject.Infrastructure.BaseRepository;
using FutureProject.Infrastructure.Persistance;
using FutureProjectApplication.Abstraction;
using FutureProjectApplication.Abstraction.IService;
using FutureProjectApplication.Service.AuthService;
using FutureProjectApplication.Service.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FutureProject.Infrastructure
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration conf)
        {
            services.AddDbContext<FutureProjectDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("FutureProjectsConnectionString"));
                
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService,AuthService>();
            return services;
        }
    }
}
