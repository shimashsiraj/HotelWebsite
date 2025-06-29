using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saint.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsImages_RoomTypes_RoomTypeId",
                table: "RoomsImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsImages",
                table: "RoomsImages");

            migrationBuilder.RenameTable(
                name: "RoomsImages",
                newName: "RoomImages");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsImages_RoomTypeId",
                table: "RoomImages",
                newName: "IX_RoomImages_RoomTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomImages",
                table: "RoomImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomImages_RoomTypes_RoomTypeId",
                table: "RoomImages",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomImages_RoomTypes_RoomTypeId",
                table: "RoomImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomImages",
                table: "RoomImages");

            migrationBuilder.RenameTable(
                name: "RoomImages",
                newName: "RoomsImages");

            migrationBuilder.RenameIndex(
                name: "IX_RoomImages_RoomTypeId",
                table: "RoomsImages",
                newName: "IX_RoomsImages_RoomTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsImages",
                table: "RoomsImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsImages_RoomTypes_RoomTypeId",
                table: "RoomsImages",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
