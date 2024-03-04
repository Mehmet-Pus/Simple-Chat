using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUser_ChatRoom_ChatRoomId",
                table: "ChatRoomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_ChatRoom_ChatRoomId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoomUser",
                table: "ChatRoomUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoom",
                table: "ChatRoom");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "ChatRoomUser",
                newName: "ChatRoomUsers");

            migrationBuilder.RenameTable(
                name: "ChatRoom",
                newName: "ChatRooms");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChatRoomId",
                table: "Messages",
                newName: "IX_Messages_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUser_ChatRoomId",
                table: "ChatRoomUsers",
                newName: "IX_ChatRoomUsers_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoomUsers",
                table: "ChatRoomUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUsers_ChatRooms_ChatRoomId",
                table: "ChatRoomUsers",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUsers_ChatRooms_ChatRoomId",
                table: "ChatRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoomUsers",
                table: "ChatRoomUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "ChatRoomUsers",
                newName: "ChatRoomUser");

            migrationBuilder.RenameTable(
                name: "ChatRooms",
                newName: "ChatRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Message",
                newName: "IX_Message_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUsers_ChatRoomId",
                table: "ChatRoomUser",
                newName: "IX_ChatRoomUser_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoomUser",
                table: "ChatRoomUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoom",
                table: "ChatRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUser_ChatRoom_ChatRoomId",
                table: "ChatRoomUser",
                column: "ChatRoomId",
                principalTable: "ChatRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_ChatRoom_ChatRoomId",
                table: "Message",
                column: "ChatRoomId",
                principalTable: "ChatRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
