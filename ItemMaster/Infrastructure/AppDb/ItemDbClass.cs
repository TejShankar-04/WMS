using ItemMaster.Infrastructure.Interfaces;
using ItemMaster.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemMaster.Infrastructure.AppDb
{
    public class ItemDbClass:DbContext, IItemDbClass
    {
        public ItemDbClass(DbContextOptions<ItemDbClass>options):base(options) 
        {
            
        }

        public DbSet<Item> Items { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
