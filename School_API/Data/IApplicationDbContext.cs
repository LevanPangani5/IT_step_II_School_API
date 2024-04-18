using Microsoft.EntityFrameworkCore;
using School_API.Data.Model;

namespace School_API.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Lector> Lectors { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
