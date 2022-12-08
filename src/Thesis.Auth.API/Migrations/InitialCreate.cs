using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thesis.Auth.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    DeviceDescription = table.Column<string>(type: "text", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthTickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
