using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    public partial class new1111111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.RenameColumn(
                name: "Transfer_Receipt",
                table: "Transactions",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "Transactions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageField",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Transactions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recipient",
                table: "Transactions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "MessageField",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recipient",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Transactions",
                newName: "Transfer_Receipt");

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MessageField = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Recipient = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });
        }
    }
}
