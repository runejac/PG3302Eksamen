using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PG3302Eksamen.Migrations
{
    public partial class new111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Bills_ToBillId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ToBillId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ToBillId",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToBillId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToBillId",
                table: "Transactions",
                column: "ToBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Bills_ToBillId",
                table: "Transactions",
                column: "ToBillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
