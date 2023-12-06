using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    wardName = table.Column<string>(type: "TEXT", nullable: true),
                    conductor = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    openingPrayer = table.Column<string>(type: "TEXT", nullable: true),
                    openingHymn = table.Column<string>(type: "TEXT", nullable: true),
                    sacramentHymn = table.Column<string>(type: "TEXT", nullable: true),
                    restHymn = table.Column<string>(type: "TEXT", nullable: true),
                    specialMusicalNumber = table.Column<string>(type: "TEXT", nullable: true),
                    closingHymn = table.Column<string>(type: "TEXT", nullable: true),
                    closingPrayer = table.Column<string>(type: "TEXT", nullable: true),
                    speakerNames = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
