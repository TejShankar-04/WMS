using Microsoft.EntityFrameworkCore;
using PO.Infrastructure.InterFaces;
using PO.Models;

namespace PO.Infrastructure.AppDB
{
    public class PODbClass:DbContext, IPODbClass
    {
        public PODbClass(DbContextOptions<PODbClass> options) : base(options)
        {
            
        }

        public DbSet<PurchaseHeader> purchaseHeaders { get; set; }
        public DbSet<Purchaseline> purchaselines { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
