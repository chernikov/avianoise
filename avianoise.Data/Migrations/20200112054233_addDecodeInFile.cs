using Microsoft.EntityFrameworkCore.Migrations;

namespace avianoise.Data.Migrations
{
    public partial class addDecodeInFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDecoded",
                table: "Files",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDecoded",
                table: "Files");
        }
    }
}
