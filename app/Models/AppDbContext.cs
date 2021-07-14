using System.Reflection;
using app.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace website.Models
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://www.thecodebuzz.com/enabling-transient-error-resiliency-enableretryonfailure/
            modelBuilder?.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=blazorsql;userid=root;pwd=rootpass;port=3306;database=db;sslmode=none;AllowPublicKeyRetrieval=True;";
                optionsBuilder.UseMySql(connectionString,
                    builder => builder.EnableRetryOnFailure());
            }
                
        }
    }
}
