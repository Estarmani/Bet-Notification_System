using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationSystem.Domain.Subscription;

namespace NotificationSystem.Infrastructure.Configs
{
    internal class SubscriberConfig : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.HasKey(x => x.SubscriberId);
            builder.OwnsOne(x => x.Wallet, x => x.ToJson());
            builder.Property(b => b.MobileNumber).HasMaxLength(11).IsRequired();
            builder.HasMany(b => b.Subscriptions).WithOne(b => b.Subcriber).HasForeignKey(b => b.SubscriberId);
            NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(o => o.SubscriberId), "subscriber_subscriberid_seq");
        }
    }
}
