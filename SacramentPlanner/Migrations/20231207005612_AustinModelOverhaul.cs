using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AustinModelOverhaul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "speakerNames",
                table: "Meeting");

            migrationBuilder.RenameColumn(
                name: "wardName",
                table: "Meeting",
                newName: "WardName");

            migrationBuilder.RenameColumn(
                name: "specialMusicalNumber",
                table: "Meeting",
                newName: "SpecialMusicalNumber");

            migrationBuilder.RenameColumn(
                name: "sacramentHymn",
                table: "Meeting",
                newName: "SacramentHymn");

            migrationBuilder.RenameColumn(
                name: "restHymn",
                table: "Meeting",
                newName: "RestHymn");

            migrationBuilder.RenameColumn(
                name: "openingPrayer",
                table: "Meeting",
                newName: "OpeningPrayer");

            migrationBuilder.RenameColumn(
                name: "openingHymn",
                table: "Meeting",
                newName: "OpeningHymn");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Meeting",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "conductor",
                table: "Meeting",
                newName: "Conductor");

            migrationBuilder.RenameColumn(
                name: "closingPrayer",
                table: "Meeting",
                newName: "ClosingPrayer");

            migrationBuilder.RenameColumn(
                name: "closingHymn",
                table: "Meeting",
                newName: "ClosingHymn");

            migrationBuilder.AlterColumn<int>(
                name: "SacramentHymn",
                table: "Meeting",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestHymn",
                table: "Meeting",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpeningPrayer",
                table: "Meeting",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OpeningHymn",
                table: "Meeting",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClosingPrayer",
                table: "Meeting",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClosingHymn",
                table: "Meeting",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TalksJson",
                table: "Meeting",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TalksJson",
                table: "Meeting");

            migrationBuilder.RenameColumn(
                name: "WardName",
                table: "Meeting",
                newName: "wardName");

            migrationBuilder.RenameColumn(
                name: "SpecialMusicalNumber",
                table: "Meeting",
                newName: "specialMusicalNumber");

            migrationBuilder.RenameColumn(
                name: "SacramentHymn",
                table: "Meeting",
                newName: "sacramentHymn");

            migrationBuilder.RenameColumn(
                name: "RestHymn",
                table: "Meeting",
                newName: "restHymn");

            migrationBuilder.RenameColumn(
                name: "OpeningPrayer",
                table: "Meeting",
                newName: "openingPrayer");

            migrationBuilder.RenameColumn(
                name: "OpeningHymn",
                table: "Meeting",
                newName: "openingHymn");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Meeting",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Conductor",
                table: "Meeting",
                newName: "conductor");

            migrationBuilder.RenameColumn(
                name: "ClosingPrayer",
                table: "Meeting",
                newName: "closingPrayer");

            migrationBuilder.RenameColumn(
                name: "ClosingHymn",
                table: "Meeting",
                newName: "closingHymn");

            migrationBuilder.AlterColumn<string>(
                name: "sacramentHymn",
                table: "Meeting",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "restHymn",
                table: "Meeting",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "openingPrayer",
                table: "Meeting",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "openingHymn",
                table: "Meeting",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "closingPrayer",
                table: "Meeting",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "closingHymn",
                table: "Meeting",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "speakerNames",
                table: "Meeting",
                type: "TEXT",
                nullable: true);
        }
    }
}
