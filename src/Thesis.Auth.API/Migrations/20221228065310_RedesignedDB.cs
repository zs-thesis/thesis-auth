using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thesis.Auth.Migrations
{
    public partial class RedesignedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiConsumers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Inn = table.Column<string>(type: "text", nullable: false),
                    LegalAddress = table.Column<string>(type: "text", nullable: false),
                    ActualAddress = table.Column<string>(type: "text", nullable: false),
                    Site = table.Column<string>(type: "text", nullable: true),
                    Director = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Note = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2022, 12, 28, 6, 53, 10, 443, DateTimeKind.Utc).AddTicks(80))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2022, 12, 28, 6, 53, 10, 442, DateTimeKind.Utc).AddTicks(9160))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "ActualAddress", "Created", "Director", "Email", "Inn", "LegalAddress", "Name", "Note", "Phone", "RefreshToken", "RefreshTokenExpires", "Site" },
                values: new object[] { new Guid("f6fcbed5-791c-4c1f-9c14-4ba03644bbf8"), "г. Астрахань, Бакинская 79Б", new DateTime(2022, 12, 28, 6, 53, 10, 443, DateTimeKind.Utc).AddTicks(720), "Загидин Селимов", "seljmov@list.ru", "1234567890", "г. Астрахань, Бакинская 79Б", "Thesis LLC", "Создано автоматически", "79887893991", null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "RefreshToken", "RefreshTokenExpires", "Role", "Surname" },
                values: new object[] { new Guid("c3ee57a8-60fe-4811-95a1-4c374efad8c4"), new DateTime(2022, 12, 28, 6, 53, 10, 442, DateTimeKind.Utc).AddTicks(9540), "seljmov@list.ru", "Загидин", "Создано автоматически", null, "79887893991", null, null, 2, "Селимов" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "ApiConsumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiConsumers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "Surname" },
                values: new object[] { new Guid("8827c40d-81a7-4131-a3a3-9450e8b6b704"), new DateTime(2022, 12, 10, 19, 42, 32, 935, DateTimeKind.Utc).AddTicks(2340), "seljmov@list.ru", "Загидин", "Создан автоматически", null, "79887893991", "Селимов" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "Email", "Name", "Note", "Patronymic", "Phone", "Role", "Surname" },
                values: new object[] { new Guid("3ea96f46-5de6-4d89-be43-bcc95f19ddf0"), new DateTime(2022, 12, 10, 19, 42, 32, 935, DateTimeKind.Utc).AddTicks(2840), "seljmov@list.ru", "Загидин", "Создан автоматически", null, "79887893991", 0, "Селимов" });
        }
    }
}
