using Microsoft.EntityFrameworkCore;
using School_API.Data.Model;

namespace School_API.Data
{
    public class ApplicationDbContext:DbContext, IApplicationDbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

       public DbSet<Student> Students { get; set; }
       public DbSet<Lector> Lectors { get; set; }
    }
}
