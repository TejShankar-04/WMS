using ItemMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemMaster.Infrastructure.Interfaces
{
    public interface IItemDbClass
    {
        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
