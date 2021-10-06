using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carshowroom.DAL.Migrations
{
    public partial class SeedAllData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyStyle", "ClientId", "Color", "Make", "Model", "OrderId", "Year" },
                values: new object[,]
                {
                    { 1, "седан", 1, "синий", "bmw", "320", null, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "кросовер", null, "черный металлик", "toyota", "land cruiser 200", null, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "LastName", "Name", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "Смит", "Андрей", "0987654343", "слесарь" },
                    { 2, "Звонкий", "Борис", "0678954433", "электрик" },
                    { 3, "Иванов", "Иван", "0989994421", "шиномонтажник" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BeginningOfWork", "EndingOfWork" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Name", "SerialNumber" },
                values: new object[,]
                {
                    { 1, "Воздушный фильтр", "WA09752" },
                    { 2, "Тормозной диск", "DF6143S" },
                    { 3, "Радиатор охлаждения двигателя", "NRF058413" },
                    { 4, "Катушка зажигания", "Facet09.6375" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyStyle", "ClientId", "Color", "Make", "Model", "OrderId", "Year" },
                values: new object[,]
                {
                    { 4, "универсал", 5, "серый металлик", "kia", "ceed 16v", 1, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "седан", 3, "синий", "nissan", "almera", 2, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderEmployee",
                columns: new[] { "EmployeeId", "OrderId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderPart",
                columns: new[] { "OrderId", "PartId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderEmployee",
                keyColumns: new[] { "EmployeeId", "OrderId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderEmployee",
                keyColumns: new[] { "EmployeeId", "OrderId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OrderEmployee",
                keyColumns: new[] { "EmployeeId", "OrderId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OrderEmployee",
                keyColumns: new[] { "EmployeeId", "OrderId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrderEmployee",
                keyColumns: new[] { "EmployeeId", "OrderId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "OrderPart",
                keyColumns: new[] { "OrderId", "PartId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderPart",
                keyColumns: new[] { "OrderId", "PartId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderPart",
                keyColumns: new[] { "OrderId", "PartId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
