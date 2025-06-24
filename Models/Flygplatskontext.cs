namespace FlygplatsApi.Models
{
    using Microsoft.EntityFrameworkCore;

    public class Flygplatskontext : DbContext
    {
        public Flygplatskontext(DbContextOptions<Flygplatskontext> options) : base(options)
        {
        }

        public DbSet<Flyg> Flyg { get; set; } = null!;

    }
}