using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class appliedtimeslots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Section",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsRemoved = table.Column<bool>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Section_TimeSlotId",
                table: "Section",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_TimeSlot_TimeSlotId",
                table: "Section",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_TimeSlot_TimeSlotId",
                table: "Section");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_Section_TimeSlotId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Section");
        }
    }
}
