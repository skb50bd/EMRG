using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Persistence.Migrations
{
    public partial class RoomsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Metadata_MetaId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Room_RoomId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_TimeSlot_TimeSlotId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Room_MetaId",
                table: "Rooms",
                newName: "IX_Rooms_MetaId");

            migrationBuilder.AlterColumn<int>(
                name: "TimeSlotId",
                table: "Section",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Metadata_MetaId",
                table: "Rooms",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Metadata_MetaId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Rooms_RoomId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_TimeSlot_TimeSlotId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_MetaId",
                table: "Room",
                newName: "IX_Room_MetaId");

            migrationBuilder.AlterColumn<int>(
                name: "TimeSlotId",
                table: "Section",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Metadata_MetaId",
                table: "Room",
                column: "MetaId",
                principalTable: "Metadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Room_RoomId",
                table: "Section",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_TimeSlot_TimeSlotId",
                table: "Section",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
