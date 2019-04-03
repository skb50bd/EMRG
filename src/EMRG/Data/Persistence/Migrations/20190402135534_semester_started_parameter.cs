using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class semester_started_parameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "hasEnded",
                table: "Semesters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasStarted",
                table: "Semesters",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasEnded",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "hasStarted",
                table: "Semesters");
        }
    }
}
