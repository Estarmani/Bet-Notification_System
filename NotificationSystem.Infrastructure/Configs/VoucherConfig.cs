using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationSystem.Domain.Voucher;


namespace NotificationSystem.Infrastructure.Configs
{
    internal class VoucherConfig : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(x => x.VoucherId);
            builder.Property(x => x.PinNumber).HasMaxLength(12).IsRequired();
            builder.Property(x => x.SerialNumber).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(o => o.VoucherId), "voucher_voucherid_seq");
        }
    }
}
