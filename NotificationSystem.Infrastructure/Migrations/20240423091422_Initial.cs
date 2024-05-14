using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "subscriber_subscriberid_seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "subscription_subscriptionid_seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "voucher_voucherid_seq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "voucherproduction_voucherproductionid_seq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(type: "integer", nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    SubscriptionType = table.Column<int>(type: "integer", nullable: false),
                    Wallet = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.SubscriberId);
                });

            migrationBuilder.CreateTable(
                name: "VoucherProduction",
                columns: table => new
                {
                    VoucherProductionId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BatchNumber = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    QuantityProduced = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherProduction", x => x.VoucherProductionId);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    SubcriptionId = table.Column<int>(type: "integer", nullable: false),
                    SubscriberId = table.Column<int>(type: "integer", nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.SubcriptionId);
                    table.ForeignKey(
                        name: "FK_Subscription_Subscriber_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscriber",
                        principalColumn: "SubscriberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "integer", nullable: false),
                    VoucherProductionId = table.Column<int>(type: "integer", nullable: false),
                    PinNumber = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    DateProduced = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    DateUsed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsedByMobileNo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_Voucher_VoucherProduction_VoucherProductionId",
                        column: x => x.VoucherProductionId,
                        principalTable: "VoucherProduction",
                        principalColumn: "VoucherProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_SubscriberId",
                table: "Subscription",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VoucherProductionId",
                table: "Voucher",
                column: "VoucherProductionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Subscriber");

            migrationBuilder.DropTable(
                name: "VoucherProduction");

            migrationBuilder.DropSequence(
                name: "subscriber_subscriberid_seq");

            migrationBuilder.DropSequence(
                name: "subscription_subscriptionid_seq");

            migrationBuilder.DropSequence(
                name: "voucher_voucherid_seq");

            migrationBuilder.DropSequence(
                name: "voucherproduction_voucherproductionid_seq");
        }
    }
}
