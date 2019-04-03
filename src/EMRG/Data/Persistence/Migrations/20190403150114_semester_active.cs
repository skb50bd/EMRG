using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class semester_active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasEnded",
                table: "Semesters");

            migrationBuilder.RenameColumn(
                name: "hasStarted",
                table: "Semesters",
                newName: "isActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Semesters",
                newName: "hasStarted");

            migrationBuilder.AddColumn<bool>(
                name: "hasEnded",
                table: "Semesters",
                nullable: false,
                defaultValue: false);
        }
    }
}
