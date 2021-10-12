using Microsoft.EntityFrameworkCore.Migrations;

namespace Carshowroom.DAL.Migrations
{
    public partial class UpdateDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployee_Employees_EmployeeId",
                table: "OrderEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployee_Orders_OrderId",
                table: "OrderEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Orders_OrderId",
                table: "OrderPart");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Parts_PartId",
                table: "OrderPart");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployee_Employees_EmployeeId",
                table: "OrderEmployee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployee_Orders_OrderId",
                table: "OrderEmployee",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Orders_OrderId",
                table: "OrderPart",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Parts_PartId",
                table: "OrderPart",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployee_Employees_EmployeeId",
                table: "OrderEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployee_Orders_OrderId",
                table: "OrderEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Orders_OrderId",
                table: "OrderPart");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPart_Parts_PartId",
                table: "OrderPart");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployee_Employees_EmployeeId",
                table: "OrderEmployee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployee_Orders_OrderId",
                table: "OrderEmployee",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Orders_OrderId",
                table: "OrderPart",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPart_Parts_PartId",
                table: "OrderPart",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
