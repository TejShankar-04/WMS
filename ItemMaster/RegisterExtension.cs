using ItemMaster.Infrastructure.AppDb;
using ItemMaster.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ItemMaster
{
    public static class RegisterExtension
    {

        public static void AddItemServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ItemDbClass>(Options => Options.UseSqlServer(configuration.GetConnectionString("ItemDbConnection")));
            services.AddScoped<IItemDbClass,ItemDbClass>();
        }
    }
}
