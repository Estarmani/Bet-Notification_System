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
    internal class WalletTransConfig : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.HasKey(w => w.WalletTransactionId);
            NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(w => w.WalletTransactionId), "wallettransaction_wallettransactionid");

            
        }
    }
}
