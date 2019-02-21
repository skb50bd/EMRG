using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class addedprograms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Program_ProgramId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Program_Departments_DepartmentId",
                table: "Program");

            migrationBuilder.DropForeignKey(
                name: "FK_Program_Metadata_MetaId",
                table: "Program");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Program_ProgramId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Program",
                table: "Program");

            migrationBuilder.RenameTable(
                name: "Program",
                newName: "Programs");

            migrationBuilder.RenameIndex(
                name: "IX_Program_MetaId",
                table: "Programs",
                newName: "IX_Programs_MetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Program_DepartmentId",
                table: "Programs",
                newName: "IX_Programs_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programs",
                table: "Programs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Programs_ProgramId",
                table: "Course",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Departments_DepartmentId",
                table: "Programs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Metadata_MetaId",
                table: "Programs",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Programs_ProgramId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Departments_DepartmentId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Metadata_MetaId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Programs_ProgramId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programs",
                table: "Programs");

            migrationBuilder.RenameTable(
                name: "Programs",
                newName: "Program");

            migrationBuilder.RenameIndex(
                name: "IX_Programs_MetaId",
                table: "Program",
                newName: "IX_Program_MetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Programs_DepartmentId",
                table: "Program",
                newName: "IX_Program_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Program",
                table: "Program",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Program_ProgramId",
                table: "Course",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Departments_DepartmentId",
                table: "Program",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Metadata_MetaId",
                table: "Program",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Program_ProgramId",
                table: "Student",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
