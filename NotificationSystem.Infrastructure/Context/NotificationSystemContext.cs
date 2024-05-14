using Microsoft.EntityFrameworkCore;
using NotificationSystem.Domain.Subscription;
using NotificationSystem.Domain.Voucher;
using NotificationSystem.Infrastructure._Core;

namespace NotificationSystem.Infrastructure.Context
{
    internal sealed class NotificationSystemContext : DbContext, INotificationSystemContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("PORT=5432;HOST=localhost; pooling=false; DATABASE=BetNotificationDb ;PASSWORD=Password@123;USER ID=postgres;PersistSecurityInfo=true")
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationSystemContext).Assembly);
        }

        public DbSet<Subscriber> Subscribers {  get; set; }
        public DbSet<Subscription> Subscriptions { get;set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherProduction> VouchersProductions { get; set;}
    }
}
