using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApproachMVC.Migrations
{
    public partial class codefirstDB004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Students");
        }
    }
}
