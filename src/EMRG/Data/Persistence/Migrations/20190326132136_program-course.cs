using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class programcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourse_Courses_CourseId",
                table: "ProgramCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourse_Metadata_Id",
                table: "ProgramCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourse_Programs_ProgramId",
                table: "ProgramCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramCourse",
                table: "ProgramCourse");

            migrationBuilder.RenameTable(
                name: "ProgramCourse",
                newName: "ProgramCourses");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramCourse_Id",
                table: "ProgramCourses",
                newName: "IX_ProgramCourses_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramCourse_CourseId",
                table: "ProgramCourses",
                newName: "IX_ProgramCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramCourses",
                table: "ProgramCourses",
                columns: new[] { "ProgramId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourses_Courses_CourseId",
                table: "ProgramCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourses_Metadata_Id",
                table: "ProgramCourses",
                column: "Id",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourses_Programs_ProgramId",
                table: "ProgramCourses",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourses_Courses_CourseId",
                table: "ProgramCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourses_Metadata_Id",
                table: "ProgramCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourses_Programs_ProgramId",
                table: "ProgramCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramCourses",
                table: "ProgramCourses");

            migrationBuilder.RenameTable(
                name: "ProgramCourses",
                newName: "ProgramCourse");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramCourses_Id",
                table: "ProgramCourse",
                newName: "IX_ProgramCourse_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramCourses_CourseId",
                table: "ProgramCourse",
                newName: "IX_ProgramCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramCourse",
                table: "ProgramCourse",
                columns: new[] { "ProgramId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourse_Courses_CourseId",
                table: "ProgramCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourse_Metadata_Id",
                table: "ProgramCourse",
                column: "Id",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourse_Programs_ProgramId",
                table: "ProgramCourse",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
