using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCalc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MacroEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calorie = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: true),
                    Carb = table.Column<int>(type: "int", nullable: true),
                    Protein = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacroEntries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MacroEntries",
                columns: new[] { "Id", "Calorie", "Carb", "Date", "Fat", "Protein" },
                values: new object[] { 1, 0, 0, new DateTime(2025, 8, 26, 13, 27, 56, 26, DateTimeKind.Local).AddTicks(8890), 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MacroEntries");
        }
    }
}
