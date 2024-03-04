using Microsoft.EntityFrameworkCore;

namespace DynamicRepositoryPattern
{
    // this class i need to create in infrastrucure
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>(_ =>
            {
                _.ToTable(Transaction.TransactionTable);
                _.HasKey(_ => _.Id);

                _.Property(_ => _.Name).IsRequired();

                _.Property(_ => _.Description).IsRequired();

                _.Property(_ => _.Gender).IsRequired();
            });

        }
    }
}
