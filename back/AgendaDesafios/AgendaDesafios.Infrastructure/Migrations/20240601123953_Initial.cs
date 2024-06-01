using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgendaDesafios.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendEmail = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SituationEvent = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calendars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phonebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonebooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phonebooks_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phonebooks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Name", "Password", "Status", "Updated" },
                values: new object[] { 1, new DateTime(2024, 6, 1, 9, 39, 53, 483, DateTimeKind.Local).AddTicks(8905), "admin@blue.com", "Admin", "yourpassword", 1, new DateTime(2024, 6, 1, 9, 39, 53, 483, DateTimeKind.Local).AddTicks(8916) });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "Description", "EndEvent", "IdUser", "SendEmail", "SituationEvent", "StartEvent", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Reunião para planejamento do próximo trimestre", new DateTime(2024, 6, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 1, new DateTime(2024, 6, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reunião de Planejamento", null },
                    { 2, "Almoço com cliente para discutir detalhes do projeto", new DateTime(2024, 6, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 1, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, "Almoço com Cliente", null }
                });

            migrationBuilder.InsertData(
                table: "Phonebooks",
                columns: new[] { "Id", "Email", "IdUser", "Name", "Phone", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "joao@example.com", 1, "João", "(11) 1234-5678", 1, null },
                    { 2, "maria@example.com", 1, "Maria", "(11) 9876-5432", 1, null },
                    { 3, "pedro@example.com", 1, "Pedro", "(11) 4567-8901", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_IdUser",
                table: "Calendars",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phonebooks_IdUser",
                table: "Phonebooks",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Phonebooks_UserId",
                table: "Phonebooks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Phonebooks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
