using System.Reflection;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Models
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
