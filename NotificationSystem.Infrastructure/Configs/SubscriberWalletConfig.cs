using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationSystem.Domain.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Infrastructure.Configs
{
    internal class SubscriberWalletConfig : IEntityTypeConfiguration<SubscriberWallet>
    {
        public void Configure(EntityTypeBuilder<SubscriberWallet> builder)
        {
           builder.HasKey(s => s.SubscriberId);
           builder.HasMany(t => t.WalletTransactions).WithOne(s => s.SubscriberWallet).HasForeignKey(s => s.SubscriberId);
        }
    }
}
