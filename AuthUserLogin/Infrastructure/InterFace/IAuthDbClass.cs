using AuthUserLogin.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthUserLogin.Infrastructure.InterFace
{
    public interface IAuthDbClass
    {
        DbSet<User> users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
