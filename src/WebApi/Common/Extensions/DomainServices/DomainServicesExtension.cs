using Domain.Services;
using Domain.Services.Interfaces;

namespace WebApi.Common.Extensions.DomainServices;

public static class DomainServicesExtension
{
    internal static void RegisterDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailService, EmailService>();
    }
}