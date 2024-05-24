using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Package",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Subscriber");

            migrationBuilder.RenameColumn(
                name: "SubscriptionType",
                table: "Subscriber",
                newName: "Package");

            migrationBuilder.RenameColumn(
                name: "DateRegistered",
                table: "Subscriber",
                newName: "ModifiedOn");

            migrationBuilder.CreateSequence(
                name: "wallettransaction_wallettransactionid",
                incrementBy: 10);

            migrationBuilder.AddColumn<string>(
                name: "PinNumber",
                table: "Subscription",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Subscriber",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PackageUnitPrice",
                table: "Subscriber",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SubscriberWallets",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberWallets", x => x.SubscriberId);
                    table.ForeignKey(
                        name: "FK_SubscriberWallets_Subscriber_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscriber",
                        principalColumn: "SubscriberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransaction",
                columns: table => new
                {
                    WalletTransactionId = table.Column<long>(type: "bigint", nullable: false),
                    SubscriberId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransaction", x => x.WalletTransactionId);
                    table.ForeignKey(
                        name: "FK_WalletTransaction_SubscriberWallets_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "SubscriberWallets",
                        principalColumn: "SubscriberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransaction_SubscriberId",
                table: "WalletTransaction",
                column: "SubscriberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletTransaction");

            migrationBuilder.DropTable(
                name: "SubscriberWallets");

            migrationBuilder.DropColumn(
                name: "PinNumber",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Subscriber");

            migrationBuilder.DropColumn(
                name: "PackageUnitPrice",
                table: "Subscriber");

            migrationBuilder.DropSequence(
                name: "wallettransaction_wallettransactionid");

            migrationBuilder.RenameColumn(
                name: "Package",
                table: "Subscriber",
                newName: "SubscriptionType");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Subscriber",
                newName: "DateRegistered");

            migrationBuilder.AddColumn<int>(
                name: "Package",
                table: "Subscription",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Subscription",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Wallet",
                table: "Subscriber",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
