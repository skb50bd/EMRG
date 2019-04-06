using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class course_enrollment_edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Metadata_MetaId",
                table: "CourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Sections_SectionId",
                table: "CourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Students_StudentId",
                table: "CourseEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrollment",
                table: "CourseEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrollment_StudentId",
                table: "CourseEnrollment");

            migrationBuilder.RenameTable(
                name: "CourseEnrollment",
                newName: "CourseEnrollments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollment_SectionId",
                table: "CourseEnrollments",
                newName: "IX_CourseEnrollments_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollment_MetaId",
                table: "CourseEnrollments",
                newName: "IX_CourseEnrollments_MetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrollments",
                table: "CourseEnrollments",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CourseEnrollments_StudentId_SectionId",
                table: "CourseEnrollments",
                columns: new[] { "StudentId", "SectionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Metadata_MetaId",
                table: "CourseEnrollments",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Sections_SectionId",
                table: "CourseEnrollments",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Students_StudentId",
                table: "CourseEnrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Metadata_MetaId",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Sections_SectionId",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Students_StudentId",
                table: "CourseEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseEnrollments",
                table: "CourseEnrollments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CourseEnrollments_StudentId_SectionId",
                table: "CourseEnrollments");

            migrationBuilder.RenameTable(
                name: "CourseEnrollments",
                newName: "CourseEnrollment");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollments_SectionId",
                table: "CourseEnrollment",
                newName: "IX_CourseEnrollment_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseEnrollments_MetaId",
                table: "CourseEnrollment",
                newName: "IX_CourseEnrollment_MetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseEnrollment",
                table: "CourseEnrollment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_StudentId",
                table: "CourseEnrollment",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Metadata_MetaId",
                table: "CourseEnrollment",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Sections_SectionId",
                table: "CourseEnrollment",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Students_StudentId",
                table: "CourseEnrollment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
