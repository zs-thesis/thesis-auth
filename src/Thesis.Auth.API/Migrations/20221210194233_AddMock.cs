using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thesis.Auth.Migrations
{
    public partial class AddMock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("5b06cb4d-deee-4c81-aeef-55efe997237c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c057ce0e-433d-4f28-b7f7-8de893939e89"));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "Surname" },
                values: new object[] { new Guid("8827c40d-81a7-4131-a3a3-9450e8b6b704"), new DateTime(2022, 12, 10, 19, 42, 32, 935, DateTimeKind.Utc).AddTicks(2340), "seljmov@list.ru", "Загидин", "Создан автоматически", null, "79887893991", "Селимов" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "Role", "Surname" },
                values: new object[] { new Guid("3ea96f46-5de6-4d89-be43-bcc95f19ddf0"), new DateTime(2022, 12, 10, 19, 42, 32, 935, DateTimeKind.Utc).AddTicks(2840), "seljmov@list.ru", "Загидин", "Создан автоматически", null, "79887893991", 0, "Селимов" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("8827c40d-81a7-4131-a3a3-9450e8b6b704"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3ea96f46-5de6-4d89-be43-bcc95f19ddf0"));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "Surname" },
                values: new object[] { new Guid("5b06cb4d-deee-4c81-aeef-55efe997237c"), new DateTime(2022, 12, 10, 23, 41, 33, 790, DateTimeKind.Local).AddTicks(300), "seljmov@list.ru", "Загидин", "Создан автоматически", null, "79887893991", "Селимов" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "Role", "Surname" },
                values: new object[] { new Guid("c057ce0e-433d-4f28-b7f7-8de893939e89"), new DateTime(2022, 12, 10, 23, 41, 33, 790, DateTimeKind.Local).AddTicks(860), "seljmov@list.ru", "Загидин", "Создан автоматически", null, "79887893991", 0, "Селимов" });
        }
    }
}
