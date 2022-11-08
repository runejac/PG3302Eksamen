using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    public partial class new11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_FromAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_ToAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ToAccountId",
                table: "Transactions",
                newName: "ToAccount");

            migrationBuilder.RenameColumn(
                name: "FromAccountId",
                table: "Transactions",
                newName: "FromAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions",
                column: "FromAccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccount",
                table: "Transactions",
                column: "ToAccount",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_FromAccount",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ToAccount",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ToAccount",
                table: "Transactions",
                newName: "ToAccountId");

            migrationBuilder.RenameColumn(
                name: "FromAccount",
                table: "Transactions",
                newName: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions",
                column: "ToAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_FromAccountId",
                table: "Transactions",
                column: "FromAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_ToAccountId",
                table: "Transactions",
                column: "ToAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
