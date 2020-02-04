using Microsoft.EntityFrameworkCore.Migrations;

namespace avianoise.Data.Migrations
{
    public partial class AddDayNightTypeToFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayNightType",
                table: "Files",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayNightType",
                table: "Files");
        }
    }
}
