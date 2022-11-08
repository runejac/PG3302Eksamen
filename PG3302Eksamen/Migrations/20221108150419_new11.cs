using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    public partial class new11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ToAccount",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions",
                column: "FromAccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ToAccount",
                table: "Bills",
                column: "ToAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ToAccount",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions",
                column: "FromAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ToAccount",
                table: "Bills",
                column: "ToAccount",
                unique: true);
        }
    }
}
