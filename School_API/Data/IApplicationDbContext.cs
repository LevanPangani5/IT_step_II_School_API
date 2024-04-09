using Microsoft.EntityFrameworkCore;
using School_API.Data.Model;

namespace School_API.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Lector> Lectors { get; }
    }

}
