using AuthUserLogin.Infrastructure.InterFace;
using AuthUserLogin.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthUserLogin.Infrastructure.AuthDb
{
    public class AuthDbClass:DbContext, IAuthDbClass
    {
        public AuthDbClass(DbContextOptions<AuthDbClass> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
