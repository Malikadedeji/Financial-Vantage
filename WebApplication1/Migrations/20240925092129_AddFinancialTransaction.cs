using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialVantage.Migrations
{
    /// <inheritdoc />
    public partial class AddFinancialTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "FinancialTransactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialInstrument",
                table: "FinancialTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "026d42b5-5b69-4c84-aaa1-236bf861cbce", null, "Admin", "ADMIN" },
                    { "3cdfa44a-1dbc-4a02-8712-c63f1b0abf29", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_AppUserId",
                table: "FinancialTransactions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialTransactions_AspNetUsers_AppUserId",
                table: "FinancialTransactions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialTransactions_AspNetUsers_AppUserId",
                table: "FinancialTransactions");

            migrationBuilder.DropIndex(
                name: "IX_FinancialTransactions_AppUserId",
                table: "FinancialTransactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "026d42b5-5b69-4c84-aaa1-236bf861cbce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cdfa44a-1dbc-4a02-8712-c63f1b0abf29");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "FinancialTransactions");

            migrationBuilder.DropColumn(
                name: "FinancialInstrument",
                table: "FinancialTransactions");
        }
    }
}
