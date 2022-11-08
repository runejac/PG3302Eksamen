using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    public partial class new1111111111111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Accounts_ToAccountId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ToAccountId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "ToAccountId",
                table: "Bills",
                newName: "ToAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ToAccount",
                table: "Bills",
                column: "ToAccount",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_ToAccount",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "ToAccount",
                table: "Bills",
                newName: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ToAccountId",
                table: "Bills",
                column: "ToAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Accounts_ToAccountId",
                table: "Bills",
                column: "ToAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
