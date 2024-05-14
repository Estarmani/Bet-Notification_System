using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationSystem.Domain.Subscription;


namespace NotificationSystem.Infrastructure.Configs
{
    internal class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.SubcriptionId);
            builder.Property(b => b.MobileNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(o => o.SubcriptionId), "subscription_subscriptionid_seq");
        }
    }
}
