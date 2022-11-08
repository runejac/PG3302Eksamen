using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions",
                column: "FromAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions",
                column: "FromAccount",
                unique: true);
        }
    }
}
