using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class addedstudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Departments_DepartmentId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Metadata_MetaId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Programs_ProgramId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Section_SectionId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_SectionId",
                table: "Students",
                newName: "IX_Students_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ProgramId",
                table: "Students",
                newName: "IX_Students_ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_MetaId",
                table: "Students",
                newName: "IX_Students_MetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_DepartmentId",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Metadata_MetaId",
                table: "Students",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programs_ProgramId",
                table: "Students",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Section_SectionId",
                table: "Students",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Metadata_MetaId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programs_ProgramId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Section_SectionId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SectionId",
                table: "Student",
                newName: "IX_Student_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ProgramId",
                table: "Student",
                newName: "IX_Student_ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_MetaId",
                table: "Student",
                newName: "IX_Student_MetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Student",
                newName: "IX_Student_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Departments_DepartmentId",
                table: "Student",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Metadata_MetaId",
                table: "Student",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Programs_ProgramId",
                table: "Student",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Section_SectionId",
                table: "Student",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
