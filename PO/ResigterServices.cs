using Microsoft.EntityFrameworkCore;
using PO.Infrastructure.AppDB;
using PO.Infrastructure.InterFaces;
using PO.Shared.AnotherAPIClass;

namespace PO
{
    public static class ResigterServices
    {
        public static void AddPOServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PODbClass>(Options => Options.UseSqlServer(configuration.GetConnectionString("PODbConnection")));
            services.AddScoped<IPODbClass, PODbClass>();
            services.AddScoped<IItemServices, ItemMasterService>();
        }
    }
}
