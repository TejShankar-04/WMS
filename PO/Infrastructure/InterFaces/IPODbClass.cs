using Microsoft.EntityFrameworkCore;
using PO.Models;

namespace PO.Infrastructure.InterFaces
{
    public interface IPODbClass
    {
        DbSet<PurchaseHeader> purchaseHeaders { get; set; }
        public DbSet<Purchaseline> purchaselines { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
