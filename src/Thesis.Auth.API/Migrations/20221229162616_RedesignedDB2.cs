using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thesis.Auth.Migrations
{
    public partial class RedesignedDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("f6fcbed5-791c-4c1f-9c14-4ba03644bbf8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3ee57a8-60fe-4811-95a1-4c374efad8c4"));

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpires",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Companies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 29, 16, 26, 16, 643, DateTimeKind.Utc).AddTicks(9790),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 12, 28, 6, 53, 10, 442, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Companies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "RefreshToken", "RefreshTokenExpires", "Role", "Surname" },
                values: new object[] { new Guid("75c87167-8c68-4bdd-b2c9-cae762896104"), new DateTime(2022, 12, 29, 16, 26, 16, 644, DateTimeKind.Utc).AddTicks(150), "seljmov@list.ru", "Загидин", "Создано автоматически", null, "79887893991", null, null, 2, "Селимов" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75c87167-8c68-4bdd-b2c9-cae762896104"));

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Companies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 28, 6, 53, 10, 442, DateTimeKind.Utc).AddTicks(9160),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 12, 29, 16, 26, 16, 643, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 28, 6, 53, 10, 443, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpires",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "ActualAddress", "Created", "Director", "Email", "Inn", "LegalAddress", "Name", "Note", "Phone", "RefreshToken", "RefreshTokenExpires", "Role", "Site" },
                values: new object[] { new Guid("f6fcbed5-791c-4c1f-9c14-4ba03644bbf8"), "г. Астрахань, Бакинская 79Б", new DateTime(2022, 12, 28, 6, 53, 10, 443, DateTimeKind.Utc).AddTicks(720), "Загидин Селимов", "seljmov@list.ru", "1234567890", "г. Астрахань, Бакинская 79Б", "Thesis LLC", "Создано автоматически", "79887893991", null, null, 0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "RefreshToken", "RefreshTokenExpires", "Role", "Surname" },
                values: new object[] { new Guid("c3ee57a8-60fe-4811-95a1-4c374efad8c4"), new DateTime(2022, 12, 28, 6, 53, 10, 442, DateTimeKind.Utc).AddTicks(9540), "seljmov@list.ru", "Загидин", "Создано автоматически", null, "79887893991", null, null, 2, "Селимов" });
        }
    }
}
