using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationSystem.Domain.Voucher;


namespace NotificationSystem.Infrastructure.Configs
{
    internal class VoucherProductionConfig : IEntityTypeConfiguration<VoucherProduction>
    {
        public void Configure(EntityTypeBuilder<VoucherProduction> builder)
        {
            builder.HasKey(x => x.VoucherProductionId);
            builder.Property(x => x.BatchNumber).HasMaxLength(8).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.QuantityProduced).IsRequired();
            builder.HasMany(x => x.Vouchers).WithOne(x => x.VoucherProduction).HasForeignKey(x => x.VoucherProductionId);
            NpgsqlPropertyBuilderExtensions.UseHiLo(builder.Property(o => o.VoucherProductionId), "voucherproduction_voucherproductionid_seq");
        }
    }
}
