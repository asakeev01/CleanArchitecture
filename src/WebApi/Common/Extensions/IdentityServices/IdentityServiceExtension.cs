using System;
using Domain.Entities.Users;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Common.Extensions.IdentityServices
{
    public static class IdentityServiceExtension
    {
        internal static void AddIdentityService(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.ConfigureOptions<AppUrlOptionsSetup>();
            services.ConfigureOptions<EmailOptionsSetup>();
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}

