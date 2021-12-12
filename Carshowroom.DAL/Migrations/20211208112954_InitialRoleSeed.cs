using Microsoft.EntityFrameworkCore.Migrations;

namespace Carshowroom.DAL.Migrations
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19b4b5dc-3896-40e3-aa85-c04fa05f983c", "eb179ca7-46d4-47cb-9ab9-926923fcad70", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15472046-26df-4146-97aa-092c7c26d43f", "c639740c-e7d8-4a34-a881-49bc47f1419f", "Dealer", "DEALER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f38d8aef-c08d-40c0-862e-6a76a6cb5595", "cb06fbc1-8aeb-4cdb-bed0-6056bc4cf8e0", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15472046-26df-4146-97aa-092c7c26d43f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b4b5dc-3896-40e3-aa85-c04fa05f983c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f38d8aef-c08d-40c0-862e-6a76a6cb5595");
        }
    }
}
