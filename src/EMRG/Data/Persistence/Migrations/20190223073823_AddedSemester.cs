using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class AddedSemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Faculties_FacultyId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Metadata_MetaId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Rooms_RoomId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_TimeSlot_TimeSlotId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Section_SectionId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Section");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "Sections");

            migrationBuilder.RenameColumn(
                name: "TimeSlotId",
                table: "Sections",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_TimeSlotId",
                table: "Sections",
                newName: "IX_Sections_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_RoomId",
                table: "Sections",
                newName: "IX_Sections_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_MetaId",
                table: "Sections",
                newName: "IX_Sections_MetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_FacultyId",
                table: "Sections",
                newName: "IX_Sections_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_CourseId",
                table: "Sections",
                newName: "IX_Sections_CourseId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TimeSlot",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TimeSlot",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "TimeSlot",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "TimeSlot",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Schedule_IsRemoved",
                table: "Sections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsRemoved = table.Column<bool>(nullable: false),
                    MetaId = table.Column<int>(nullable: true),
                    Season = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semester_Metadata_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_ScheduleId",
                table: "TimeSlot",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_MetaId",
                table: "Semester",
                column: "MetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Faculties_FacultyId",
                table: "Sections",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Metadata_MetaId",
                table: "Sections",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Rooms_RoomId",
                table: "Sections",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Semester_SemesterId",
                table: "Sections",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Sections_SectionId",
                table: "Students",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlot_Sections_ScheduleId",
                table: "TimeSlot",
                column: "ScheduleId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Faculties_FacultyId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Metadata_MetaId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Rooms_RoomId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Semester_SemesterId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Sections_SectionId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlot_Sections_ScheduleId",
                table: "TimeSlot");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlot_ScheduleId",
                table: "TimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Schedule_IsRemoved",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "Section");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Section",
                newName: "TimeSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_SemesterId",
                table: "Section",
                newName: "IX_Section_TimeSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_RoomId",
                table: "Section",
                newName: "IX_Section_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_MetaId",
                table: "Section",
                newName: "IX_Section_MetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_FacultyId",
                table: "Section",
                newName: "IX_Section_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_CourseId",
                table: "Section",
                newName: "IX_Section_CourseId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "TimeSlot",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "TimeSlot",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "TimeSlot",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "Section",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Courses_CourseId",
                table: "Section",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Faculties_FacultyId",
                table: "Section",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Metadata_MetaId",
                table: "Section",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Rooms_RoomId",
                table: "Section",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_TimeSlot_TimeSlotId",
                table: "Section",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Section_SectionId",
                table: "Students",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
