/*using DynamicRepositoryPattern.Infrastrucure.Entity;
using Microsoft.EntityFrameworkCore;

namespace DynamicRepositoryPattern.Data
{
    public class EfDbContext : DbContext
    {
        protected string ConnectionString { get; }
        protected bool EnableEntityFrameworkLogging { get; }


        public EfDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "DevConnection",
                    b => b.MigrationsAssembly("DynamicRepositoryPattern.Infrastrucuture"));
            }
        }
    }
}
*/