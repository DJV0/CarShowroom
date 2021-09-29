using Microsoft.EntityFrameworkCore.Migrations;

namespace Carshowroom.DAL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Terentiev", "Oleh", "0981234141" },
                    { 2, "Simonenko", "Roman", "0961234567" },
                    { 3, "Klimov", "Petr", "0671234567" },
                    { 4, "Polunin", "Sergei", "0638765432" },
                    { 5, "Green", "Stas", "0979876543" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
