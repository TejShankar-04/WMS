using AuthUserLogin.Infrastructure;
using AuthUserLogin.Infrastructure.AuthDb;
using AuthUserLogin.Infrastructure.InterFace;
using AuthUserLogin.Shared.Token;
using Microsoft.EntityFrameworkCore;

namespace AuthUserLogin
{
    public static class RegisterServices
    {
        public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbClass>(Options => Options.UseSqlServer(configuration.GetConnectionString("AuthDbConnection")));
            services.AddScoped<IAuthDbClass, AuthDbClass>();
            services.AddScoped<ITokenServices, TokenServices>();
        }
    }
}
