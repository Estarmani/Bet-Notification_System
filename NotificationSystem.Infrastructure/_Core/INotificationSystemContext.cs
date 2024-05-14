using Microsoft.EntityFrameworkCore;
using NotificationSystem.Domain.Subscription;
using NotificationSystem.Domain.Voucher;


namespace NotificationSystem.Infrastructure._Core
{
    public interface INotificationSystemContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<VoucherProduction> VouchersProductions { get; set; }
        public DbSet<Voucher> Vouchers {  get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
