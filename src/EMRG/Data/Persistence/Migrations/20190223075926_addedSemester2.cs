using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class addedSemester2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Semester_SemesterId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Semester_Metadata_MetaId",
                table: "Semester");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semester",
                table: "Semester");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameIndex(
                name: "IX_Semester_MetaId",
                table: "Semesters",
                newName: "IX_Semesters_MetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Semesters_SemesterId",
                table: "Sections",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Metadata_MetaId",
                table: "Semesters",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Semesters_SemesterId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Metadata_MetaId",
                table: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_MetaId",
                table: "Semester",
                newName: "IX_Semester_MetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semester",
                table: "Semester",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Semester_SemesterId",
                table: "Sections",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_Metadata_MetaId",
                table: "Semester",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
